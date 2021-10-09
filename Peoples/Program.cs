using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peoples
{
	class Comparer : IComparer<People>
	{
			public int Compare(People x, People y)
			{
			if (x.СalculateSalary() > y.СalculateSalary()) return 1;
			if (x.СalculateSalary() < y.СalculateSalary()) return -1;
			return 0;


			//return x.СalculateSalary() > y.СalculateSalary() ? 1 : -1;

		}
	}
	

	class Program
	{
		private static Random random = new Random();

		static People GenerateEmployee()
		{
			var names = new[] { "Анатолий", "Глеб", "Клим", "Мартин", "Лазарь", "Владлен", "Клим", "Панкратий", "Рубен", "Герман" };
			var secondName = new[] { "Григорьев", "Фокин", "Шестаков", "Хохлов", "Шубин", "Бирюков", "Копылов", "Горбунов", "Лыткин", "Соколов" };

			var typeIndex = random.Next(0, 2);
			var salary = random.Next(200, 501);
			var salaryIndex = random.Next(100, 160);
			switch (typeIndex)
			{
				case 0:
					return new Freelancer(names[random.Next(0, 10)], secondName[random.Next(0, 10)], salary);
				case 1:
					return new Worker(names[random.Next(0, 10)], secondName[random.Next(0, 10)], salary * salaryIndex);
			}
			return null;
		}

		static void Main(string[] args)
		{

			People[] peoples = new People[10];
			for (int i = 0; i < peoples.Length; i++)
				peoples[i] = GenerateEmployee();

			foreach (var people in peoples)
				Console.WriteLine(people);

			Console.WriteLine();
			Array.Sort(peoples, new Comparer());

			Console.WriteLine("\n*** Отсортированный массив сотрудников ***\n");
			foreach (var people in peoples)
				Console.WriteLine(people);

			
			Console.ReadLine();
		}
	}
}
