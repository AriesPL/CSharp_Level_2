using Asteroid.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroid.GameObj
{
	class Bullet : BaseGameObj
	{
		public Bullet(Point startPos, Point movePos, Size sizeObj) : base(startPos, movePos, sizeObj)
		{

		}

		public override void Draw()
		{
			GameOpt.Buffer.Graphics.DrawImage(Resources.laserRed011, startPos.X, startPos.Y, sizeObj.Width, sizeObj.Height);
		}

		public override void Update()
		{
			startPos.X = startPos.X + movePos.X;
			
		}
	}
}
