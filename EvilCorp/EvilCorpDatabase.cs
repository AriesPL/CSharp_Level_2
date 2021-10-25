using EvilCorp.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvilCorp
{

	public class EvilCorpDatabase
	{
		private const string ConnectionStringSQL = "Data Source =DESKTOP-4HT1J9M\\SQLEXPRESS; Initial Catalog = StaffSQL; User ID = Userg; Password = 123456";

		//private static string[] FirstName = { "Алексей","Андрей" ,"Егор" ,"Александр" ,"Мотвей","Станислав" };
		//private static string[] SecondName = { "Алексеевич", "Андреевич", "Егорович", "Александрович", "Мотвеевич", "Станиславович" };
		//private static string[] LastName = { "Сергеев", "Бондаренко", "Петров", "Соколов", "Давыдов", "Измайлов" };
		//private static string[] Phone_Prefix = { "902", "913", "923" };
		//private static int Char_Bound_L = 65;
		//private static int Char_Bound_H = 90;

		public Random _random = new Random();
		public ObservableCollection<Staff> Staffs { get; set; }

		public EvilCorpDatabase()
		{
			Staffs = new ObservableCollection<Staff>();
			LoadFromDatabase();
			//GenerateEvilContacts(50);
			//SQLSyncTo();
		}

		//public void SQLSyncTo()
		//{
		//	foreach(var staff in Staffs)
		//	{
		//		AddStaff(staff);
		//	}
		//}
		private void LoadFromDatabase()
		{
			string sqlExpression = "SELECT * FROM StaffSQL"; 
			using (SqlConnection _sqlConnection = new SqlConnection(ConnectionStringSQL))
			{
				_sqlConnection.Open();
				SqlCommand _command = new SqlCommand(sqlExpression, _sqlConnection);
				using (SqlDataReader reader = _command.ExecuteReader())
				{
					if (reader.HasRows)        // Если есть данные
					{
						while (reader.Read())  // Построчно считываем данные
						{
							var staff = new Staff()
							{
								Phone = reader.GetValue(0).ToString(), // Прочитать из столбца
								LastName = reader["LastName"].ToString(), //Прочитать из столбца LastName
								Name = reader.GetString(2),                 // Взять строковое значение из столбца
								SecondName = reader["SecondName"].ToString(),
								Comment = reader["Comment"].ToString(),
								FreeNow = reader.GetBoolean(4),
								Category = (StaffCategory)reader.GetInt32(6)
							};
							Staffs.Add(staff);
						}
					}
				}
			}
		}

		public int AddStaff(Staff staff)
		{
			using(SqlConnection _sqlConnection = new SqlConnection(ConnectionStringSQL))
			{
				_sqlConnection.Open();

				var _loked = staff.FreeNow ? 1 : 0;
				string _sqlExpression = $@"INSERT INTO StaffSQL (Phone,FirstName,LastName,SecondName,Comment,FreeNow,StaffCategory)
											VALUES ('{staff.Phone}', '{staff.Name}', '{staff.LastName}', '{staff.SecondName}', '{staff.Comment}', '{_loked}', '{(int)staff.Category}')";
				var _command = new SqlCommand(_sqlExpression, _sqlConnection);
				var _exRes = _command.ExecuteNonQuery();
				if (_exRes > 0)
				{
					Staffs.Add(staff);
				}
				return _exRes;
			}
			
		}
		public int UpdateStaff(Staff staff)
		{
			using (SqlConnection _sqlConnection = new SqlConnection(ConnectionStringSQL))
			{
				_sqlConnection.Open();

				var _locked = staff.FreeNow ? 1 : 0;
				string sqlExpression = $@"UPDATE StaffSQL 
                    SET LastName = '{staff.LastName}', FirstName = '{staff.Name}', SecondName = '{staff.SecondName}', Comment = '{staff.Comment}', Locked = {_locked}, CategoryId = {(int)staff.Category}
                    WHERE phone = '{staff.Phone}'";
				var _command = new SqlCommand(sqlExpression, _sqlConnection);
				return _command.ExecuteNonQuery();
			}
		}

		public int RemoveStaff(Staff staff)
		{
			using (SqlConnection _sqlConnection = new SqlConnection(ConnectionStringSQL))
			{
				_sqlConnection.Open();

				string sqlExpression = $@"DELETE FROM StaffSQL WHERE Phone = '{staff.Phone}'";
				var _command = new SqlCommand(sqlExpression, _sqlConnection);
				var res = _command.ExecuteNonQuery();
				if (res > 0)
				{
					Staffs.Remove(staff);
				}
				return res;
			}
		}


		//private string GenerateSymbols(int simbolsCount)
		//{
		//	StringBuilder stringBuilder = new StringBuilder();
		//	for (int i = 0; i < simbolsCount; i++)
		//	{
		//		stringBuilder.Append((char)(Char_Bound_L + _random.Next(Char_Bound_H - Char_Bound_L)));
		//	}
		//	return stringBuilder.ToString();
		//}


		//private string GeneratePhone()
		//{
		//	StringBuilder stringBuilder = new StringBuilder();
		//	stringBuilder.Append("+7").Append(Phone_Prefix[_random.Next(3)]);
		//	for (int i = 0; i < 6; i++)
		//	{
		//		stringBuilder.Append(_random.Next(10));
		//	}
		//	return stringBuilder.ToString();
		//}

		//private void GenerateEvilContacts(int contactCounts)
		//{
		//	Staffs.Clear();

		//	string name;
		//	string secondName;
		//	string lastName;
		//	string comment;

		//	bool freeNow;
		//	var category = (StaffCategory)_random.Next(0, 6)+1;

		//	for (int i = 0; i < contactCounts; i++)
		//	{
		//		name = FirstName[_random.Next(0, 5)];
		//		secondName = SecondName[_random.Next(0, 5)];
		//		lastName = LastName[_random.Next(0, 5)];
		//		comment = GenerateSymbols(_random.Next(0, 5) + 10);
		//		freeNow = _random.Next(0, 2) == 0 ? false : true;
		//		category = (StaffCategory)_random.Next(0, 6)+1;

		//		string phone = GeneratePhone();
		//		Staffs.Add(new Staff(phone, name, secondName, lastName, comment, freeNow, category));
		//	}
	}
}

