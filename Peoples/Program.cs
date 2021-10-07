using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peoples
{
	class Comparer : IComparer<Worker>
	{
		public int Compare(Worker x, Worker y)
		{
			return x.payMonth - y.payMonth;
		}
	}
	
	class Program
	{
		static void Main(string[] args)
		{

			var peoples = new Worker[]
				{
					new Worker("Аксель","Фоли",20,20000),
					new Worker("Андрей","Фоли",24,120000),
					new Worker("Алексей","Фоли",26,520000),
					new Worker("Астап","Фоли",30,23000),
					new Worker("Август","Фоли",40,25400),
				};


			Array.Sort(peoples,new Comparer());

			foreach(var el in peoples)
			{
				Console.WriteLine("{0} {1} {2} {3} \n", el.name, el.secondName, el.age, el.payMonth);
					}
			Console.ReadLine();
		}
	}
}
