using Asteroid.Events;
using Asteroid.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroid.GameObj
{
	class Ship : BaseGameObj
	{
		public event EventHandler<DieEventArgs> DieNow;
		

		protected int _energe = 100;
		private int _lastDamage = 0;
		private int _score = 0;
		
		public int Score
		{
			get { return _score; }
		}

		public int Energy
		{
			get { return _energe; }
		}

		public void EnergyLow(int damage)
		{
			_lastDamage = damage;
			_energe = _energe - damage;
		}
		
		public void EnergyUp(int healing)
		{
			_energe = _energe + healing;
		}

		public void ScoreUp()
		{
			_score++;
		}



		public Ship(Point startPos, Point movePos, Size sizeObj) : base(startPos, movePos, sizeObj)
		{
		}

		public void Up()
		{
			if (startPos.Y > 0) startPos.Y = startPos.Y - movePos.Y;
		}

		public void Down()
		{
			if (startPos.Y < GameOpt.Height - sizeObj.Height) startPos.Y = startPos.Y + movePos.Y;
		}

		public override void Draw()
		{
			GameOpt.Buffer.Graphics.DrawImage(Resources.ship, startPos.X, startPos.Y, sizeObj.Width, sizeObj.Height);
		}

		public override void Update()
		{
		}

		public void Die()
		{
			if (DieNow != null)
			{
				DieNow.Invoke(this, new DieEventArgs(_lastDamage));
				
			}
		}
		

	}
}
