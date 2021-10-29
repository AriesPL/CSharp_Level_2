using EvilCorp.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace EvilCorp.WebService
{
	/// <summary>
	/// Сводное описание для EvilCorpService
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
	// [System.Web.Script.Services.ScriptService]
	public class EvilCorpService : System.Web.Services.WebService
	{
		private const string ConnectionStringSQL = "Data Source =DESKTOP-4HT1J9M\\SQLEXPRESS; Initial Catalog = StaffSQL; User ID = Userg; Password = 123456";

		[WebMethod]
		public ObservableCollection<Staff> LoadStaff()
		{
			ObservableCollection<Staff> _staff = new ObservableCollection<Staff>();
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
							_staff.Add(staff);
						}
					}
					return _staff;
				}
			}
		}
		[WebMethod]
		public int AddStaff(Staff staff)
		{
			using (SqlConnection _sqlConnection = new SqlConnection(ConnectionStringSQL))
			{
				_sqlConnection.Open();

				//var _loked = staff.FreeNow ? 1 : 0;
				string _sqlExpression = $@"INSERT INTO StaffSQL (Phone,FirstName,LastName,SecondName,Comment,FreeNow,StaffCategory)
											VALUES ('{staff.Phone}','{staff.Name}','{staff.LastName}','{staff.SecondName}','{staff.Comment}','{staff.FreeNow}','{(int)staff.Category}')";
				var _command = new SqlCommand(_sqlExpression, _sqlConnection);
				return _command.ExecuteNonQuery();
				//if (_exRes > 0)
				//{
				//	Staffs.Add(staff); 
				//}
				//return _exRes;
			}

		}
		[WebMethod]
		public int UpdateStaff(Staff staff)
		{
			using (SqlConnection _sqlConnection = new SqlConnection(ConnectionStringSQL))
			{
				_sqlConnection.Open();

				var _locked = staff.FreeNow ? 1 : 0;
				string sqlExpression = $@"UPDATE StaffSQL 
                    SET LastName = '{staff.LastName}', FirstName = '{staff.Name}', SecondName = '{staff.SecondName}', Comment = '{staff.Comment}', FreeNow = {_locked}, StaffCategory = {(int)staff.Category}
                    WHERE phone = '{staff.Phone}'";
				var _command = new SqlCommand(sqlExpression, _sqlConnection);
				return _command.ExecuteNonQuery();
			}
		}
		[WebMethod]
		public int RemoveStaff(Staff staff)
		{
			using (SqlConnection _sqlConnection = new SqlConnection(ConnectionStringSQL))
			{
				_sqlConnection.Open();

				string sqlExpression = $@"DELETE FROM StaffSQL WHERE Phone = '{staff.Phone}'";
				var _command = new SqlCommand(sqlExpression, _sqlConnection);
				return _command.ExecuteNonQuery();
				//if (res > 0)
				//{
				//	Staffs.Remove(staff);
				//}
				//return res;
			}
		}
	}
}
