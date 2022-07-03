using EvilCorp.Commun.EvilCorpService;
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
		//private static string[] FirstName = { "Алексей","Андрей" ,"Егор" ,"Александр" ,"Мотвей","Станислав" };
		//private static string[] SecondName = { "Алексеевич", "Андреевич", "Егорович", "Александрович", "Мотвеевич", "Станиславович" };
		//private static string[] LastName = { "Сергеев", "Бондаренко", "Петров", "Соколов", "Давыдов", "Измайлов" };
		//private static string[] Phone_Prefix = { "902", "913", "923" };
		//private static int Char_Bound_L = 65;
		//private static int Char_Bound_H = 90;
		//public Random _random = new Random();
		private EvilCorpServiceSoapClient _evilCorpServiceSoapClient = new EvilCorpServiceSoapClient();
		public ObservableCollection<Staff> Staffs { get; set; }

		public EvilCorpDatabase()
		{
			Staffs = new ObservableCollection<Staff>();
			Load();
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
		private void Load()
		{
			foreach(var el in _evilCorpServiceSoapClient.LoadStaff())
			{
				Staffs.Add(el);
			}
		}

		public int Add(Staff staff)
		{
			var res = _evilCorpServiceSoapClient.AddStaff(staff);
			if(res > 0)
			{
				Staffs.Add(staff);
			}
			return res;
			
		}
		public int Update(Staff staff)
		{
			return _evilCorpServiceSoapClient.UpdateStaff(staff);
		}

		public int Remove(Staff staff)
		{
			var res = _evilCorpServiceSoapClient.RemoveStaff(staff);
			if( res > 0)
			{
				Staffs.Remove(staff);
			}
			return res;
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

