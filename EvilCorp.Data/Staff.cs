using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvilCorp.Data
{
	public class Staff
	{
		public string Phone { get; set; }
		public string Name { get; set; }
		public string SecondName { get; set; }
		public string LastName { get; set; }
		public string Comment { get; set; }
		public bool FreeNow { get; set; }
		public StaffCategory Category { get; set; } = StaffCategory.Раб;

		public string FIO
		{
			get { return $"{LastName} {Name} {SecondName}"; }
		}
		public Staff() { }

		public Staff(string phone, string name, string secondname, string lastname, string comment, bool freenow, StaffCategory category)
		{
			Phone = phone;
			Name = name;
			SecondName = secondname;
			LastName = lastname;
			Comment = comment;
			FreeNow = freenow;
			Category = category;
		}

	}
}
