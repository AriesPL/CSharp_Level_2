using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peoples
{
	abstract class People
	{
		string name;
		string secondName;
		int age;

		public People(string name,string secondName,int age )
		{
			this.name = name;
			this.secondName = secondName;
			this.age = age;
		}



	}
}
