using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peoples
{
	public abstract class People
	{
		public string name { get; set; }
		public string secondName { get; set; }
		public decimal salary { get; set; }

		public People(string name, string secondName, decimal salary)
		{
			this.name = name;
			this.secondName = secondName;
			this.salary = salary;
		}

		public abstract decimal СalculateSalary();





	}
}
