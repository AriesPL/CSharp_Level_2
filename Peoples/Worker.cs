using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peoples
{
	class Worker : People
	{
		int payMonth;

		public Worker(string name, string secondName, int age , int payMonth) : base(name, secondName, age)
		{
			
			this.payMonth = payMonth;

		}

	}
}
