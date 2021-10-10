using Asteroid.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroid.GameObj
{
	class Comets : BaseGameObj
	{
		public Comets(Point startPos, Point movePos,Size sizeObj) : base (startPos,movePos,sizeObj)
		{
		}

		public override void Draw()
		{
			GameOpt.Buffer.Graphics.DrawImage(Resources.star3, startPos.X, startPos.Y, sizeObj.Width, sizeObj.Height);
		}
		
	}
}
