using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleColection
{
	class Program
	{
		static int Counter(int x, int y)
		{ 
			return x > y ? 1 : -1;
		}

		static void Main(string[] args)
		{

			List<int> vs = new List<int>() { 1, 2, 3, 4, 2 };

			foreach (var el in vs)
			{
				Console.Write(el + " ");
			}
			Console.WriteLine();

			Counter(vs);

			Console.ReadLine();
		}

		private static void Counter(List<int> vs)
		{
			int count = 0;
			for (int i = 0; i < vs.Count; i++)
			{
				
				for (int j = 0; j < vs.Count; j++)
				{
					if (vs[i] == vs[j])
					{
						
						count++;
						if (count < 2)
							Console.WriteLine($"{vs[i]}:");

					}
					
				}
				Console.Write(count);
			}
			
		}
	}
}
