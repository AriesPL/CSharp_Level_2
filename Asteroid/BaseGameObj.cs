using Asteroid.Collisions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroid
{
	abstract class BaseGameObj : ICollision 
	{
		protected Point startPos;
		protected Point movePos;
		protected Size sizeObj;

		public BaseGameObj(Point startPos, Point movePos, Size sizeObj)
		{
			this.startPos = startPos;
			this.movePos = movePos;
			this.sizeObj = sizeObj;
		}
		public Rectangle Rect
		{
			get
			{
				return new Rectangle(startPos, sizeObj);
			}
		}

		public bool Collision(ICollision obj)
		{
			return obj.Rect.IntersectsWith(Rect);
		}

		public abstract void Draw();

		public virtual void Update()
		{
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
