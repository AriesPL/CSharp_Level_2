using Asteroid.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroid
{
	class Asteroids
	{
		protected Point startPos;
		protected Point movePos;
		protected Size sizeObj;

		public Asteroids(Point startPos,Point movePos,Size sizeObj)
		{
			this.startPos = startPos;
			this.movePos = movePos;
			this.sizeObj = sizeObj;
		}

		public virtual void Draw()
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
		public virtual void Update()
		{
			//TODO

			startPos.X = startPos.X + movePos.X;
			startPos.Y = startPos.Y + movePos.Y;
			ChangeDirection();
		}

		private void ChangeDirection()
		{
			
			if (startPos.X < 0) movePos.X = -movePos.X;
			if (startPos.X > GameOpt.Widht) movePos.X = -movePos.X;

			if (startPos.Y < 0) movePos.Y = -movePos.Y;
			if (startPos.Y > GameOpt.Height) movePos.Y = -movePos.Y;
		}
	}
}
