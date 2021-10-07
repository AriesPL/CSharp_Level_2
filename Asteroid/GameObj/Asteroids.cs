using Asteroid.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroid
{
	class Asteroids : BaseGameObj
	{
		

		public Asteroids(Point startPos,Point movePos,Size sizeObj) : base (startPos, movePos, sizeObj)
		{
			
		}

		public override void Draw()
		{
			if (sizeObj.Width < 30)
				GameOpt.Buffer.Graphics.DrawImage(Resources.meteorBrown_big4, startPos.X, startPos.Y, sizeObj.Width, sizeObj.Height);
			if (sizeObj.Width > 30 && sizeObj.Width < 50)
				GameOpt.Buffer.Graphics.DrawImage(Resources.meteorBrown_big3, startPos.X, startPos.Y, sizeObj.Width, sizeObj.Height);
			if (sizeObj.Width > 50 && sizeObj.Width < 80)
				GameOpt.Buffer.Graphics.DrawImage(Resources.meteorBrown_big2, startPos.X, startPos.Y, sizeObj.Width, sizeObj.Height);
			if (sizeObj.Width > 80)
				GameOpt.Buffer.Graphics.DrawImage(Resources.meteorBrown_big1, startPos.X, startPos.Y, sizeObj.Width, sizeObj.Height);
		}

	}
}
