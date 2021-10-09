using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peoples
{
	class Freelancer : People
	{
		

		public Freelancer(string name, string secondName, decimal salary) : base(name, secondName, salary)
		{
		}

		public override decimal СalculateSalary()
		{
			return (decimal)20.8 * 8 * salary;
		}

		public override string ToString()
		{
			return $"{secondName} {name}; Фрилансер; Среднемесячная заработная плата: {СalculateSalary()} (руб.); Почасовая ставка: {salary} (руб.)";
		}
	}
}
