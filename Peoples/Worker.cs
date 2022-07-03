using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peoples
{
	class Worker : People
	{
	

		public Worker(string name, string secondName, decimal salary) : base(name, secondName, salary)
		{
		}

		public override decimal СalculateSalary()
		{
			return salary;
		}

		public override string ToString()
		{
			return $"{secondName} {name}; Рабочий; Среднемесячная заработная плата (фиксированная месячная оплата): {СalculateSalary()} (руб.)";
		}


	}
}
