using EvilCorp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvilCorp
{

	public class EvilCorpDatabase
	{
		private static string[] Phone_Prefix = { "902", "913", "923" };
		private static int Char_Bound_L = 65;
		private static int Char_Bound_H = 90;

		public Random _random = new Random();
		public List<Staff> Staffs { get; set; }

		public EvilCorpDatabase()
		{
			Staffs = new List<Staff>();
			GenerateEvilContacts(50);
		}

		private string GenerateSymbols(int simbolsCount)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < simbolsCount; i++)
			{
				stringBuilder.Append((char)(Char_Bound_L + _random.Next(Char_Bound_H - Char_Bound_L)));
			}
			return stringBuilder.ToString();
		}


		private string GeneratePhone()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("+7").Append(Phone_Prefix[_random.Next(3)]);
			for (int i = 0; i < 6; i++)
			{
				stringBuilder.Append(_random.Next(10));
			}
			return stringBuilder.ToString();
		}

		private void GenerateEvilContacts(int contactCounts)
		{
			Staffs.Clear();

			string name = GenerateSymbols(_random.Next(6) + 5);
			string secondName = GenerateSymbols(_random.Next(6) + 5);
			string lastName = GenerateSymbols(_random.Next(6) + 5);
			string comment = GenerateSymbols(_random.Next(6) + 50);

			var freeNow = _random.Next(0, 2) == 0 ? false : true;
			var category = (StaffCategory)_random.Next(0, 6);

			for (int i = 0; i < contactCounts; i++)
			{
				if (_random.Next(2) == 0)
				{
					name = GenerateSymbols(_random.Next(6) + 5);
					secondName = GenerateSymbols(_random.Next(6) + 5);
					lastName = GenerateSymbols(_random.Next(6) + 5);
					comment = GenerateSymbols(_random.Next(6) + 50);
					freeNow = _random.Next(0, 2) == 0 ? false : true;
					category = (StaffCategory)_random.Next(0, 6);
				}
				string phone = GeneratePhone();
				Staffs.Add(new Staff(phone, name, secondName, lastName, comment, freeNow, category));
			}
		}
	}
}
