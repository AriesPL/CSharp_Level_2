using Asteroid.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroid.GameObj
{
	class Stars : BaseGameObj
	{

		public Stars(Point startPos, Point movePos, Size sizeObj) : base(startPos, movePos, sizeObj)
		{

		}

		public override void Draw()
		{
			if (sizeObj.Width < 15)
				GameOpt.Buffer.Graphics.DrawImage(Resources.star2, startPos.X, startPos.Y, sizeObj.Width, sizeObj.Height);
			if (sizeObj.Width > 15)
				GameOpt.Buffer.Graphics.DrawImage(Resources.star1, startPos.X, startPos.Y, sizeObj.Width, sizeObj.Height);
		}	
	}
}
