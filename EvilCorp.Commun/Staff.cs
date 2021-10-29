using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvilCorp.Commun.EvilCorpService
{
	public partial class Staff : ICloneable
	{
		public object Clone()
		{
			return this.MemberwiseClone();
		}
	}
}
