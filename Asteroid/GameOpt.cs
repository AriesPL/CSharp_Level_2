using Asteroid.GameObj;
using Asteroid.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteroid
{
	static class GameOpt
	{
		private static BufferedGraphicsContext _buffContext;
		public static BufferedGraphics Buffer;
		static Random _random = new Random();
		static Timer _timer;

		static BaseGameObj[] _asteroids;
		static BaseGameObj[] _stars;
		static BaseGameObj[] _comets;
		static Bullet _bullet;
		static Ship _ship;

		public static int Widht { get; set; }
		public static int Height { get; set; }

		public static void Init(Form form)
		{
			_buffContext = BufferedGraphicsManager.Current;
			Graphics graphics = form.CreateGraphics();

			Widht = form.ClientSize.Width;
			Height = form.ClientSize.Height;

			Buffer = _buffContext.Allocate(graphics, new Rectangle(0, 0, Widht, Height));

			Load();

			_timer = new Timer();
			_timer.Interval = 40;
			_timer.Start();
			_timer.Tick += Timer_Tick;

			form.KeyDown += Form_KeyDown;

		}

		private static void Form_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Up) _ship.Up();
			if (e.KeyCode == Keys.Down) _ship.Down();
			if (e.KeyCode == Keys.ControlKey && _bullet == null)
				_bullet = new Bullet(new Point(_ship.Rect.X + 20, _ship.Rect.Y + 18), new Point(15, 0), new Size(74, 25));
		}

		private static void Timer_Tick(object sender, EventArgs e)
		{
			Update();
			Draw();
		}

		public static void Draw()
		{
			Buffer.Graphics.DrawImage(Resources.background, new Rectangle(0, 0, Widht, Height));

			foreach (BaseGameObj star in _stars)
			{
				star.Draw();
			}

			Buffer.Graphics.DrawImage(Resources.planet, new Rectangle(40, 40, 100, 100));

			foreach (BaseGameObj asteroid in _asteroids)
			{
				if (asteroid != null) asteroid.Draw();
			}

			foreach (BaseGameObj comet in _comets)
			{
				if(comet != null) comet.Draw();
			}
			if (_bullet != null) _bullet.Draw();

			if (_ship != null)
			{
				_ship.Draw();
				Buffer.Graphics.DrawString($"Energy = {_ship.Energy}", SystemFonts.DefaultFont, Brushes.White, 0, 0);
				Buffer.Graphics.DrawString($"Score = {_ship.Score}", SystemFonts.DefaultFont, Brushes.White, 70, 0);
			}

			Buffer.Render();
		}

		public static void Update()
		{
			for (int i = 0; i < _asteroids.Length; i++)
			{
				if (_asteroids[i] == null) continue;
				
				_asteroids[i].Update();

				if (_bullet != null && _asteroids[i].Collision(_bullet))
				{
					_bullet = null;
					_asteroids[i] = null;
					_ship.ScoreUp();
					continue;
				}
				if(_ship != null && _asteroids[i].Collision(_ship))
				{
					_asteroids[i] = null;
					_ship.EnergyLow(35);
					if (_ship.Energy <= 0)
					{ 
					_ship.Die();
					
					} 
				}
			}

			foreach (BaseGameObj star in _stars)
			{
				star.Update();
			}


			for (int i = 0; i < _comets.Length; i++)
			{
				if (_comets[i] == null) continue;

				_comets[i].Update();

				if (_comets[i] != null && _comets[i].Collision(_ship))
				{
					_comets[i] = null;
					if(_ship.Energy < 100) _ship.EnergyUp(70);
				}
				
			}

			if (_bullet != null)
			{
				_bullet.Update();
				if (_bullet.Rect.X > Widht) _bullet = null;
			}
		}

		public static void Load()
		{
			
			_ship = new Ship(new Point(10, 300), new Point(5, 5), new Size(45, 60));
			_ship.DieNow += OnDieNow;

			_asteroids = new BaseGameObj[_random.Next(10, 20)];
			for (int i = 0; i < _asteroids.Length; i++)
			{
				int sizeAster = _random.Next(10, 100);
				_asteroids[i] = new Asteroids(new Point(_random.Next(400, 870), _random.Next(10,350)), new Point(-i , -i ), new Size(sizeAster, sizeAster));
			}


			_stars = new BaseGameObj[_random.Next(10, 20)];
			for (int i = 0; i < _stars.Length; i++)
			{
				int sizeStar = _random.Next(5, 25);
				_stars[i] = new Stars(new Point(_random.Next(1, 900), _random.Next(1, 450)), new Point(i, 1), new Size(sizeStar, sizeStar));
			}

			_comets = new BaseGameObj[2];
			for (int i = 0; i < _comets.Length; i++)
			{
				_comets[i] = new Comets(new Point(_random.Next(20, 900), _random.Next(1, 450)), new Point(10, 1), new Size(40, 40));
			}
		}

		private static void OnDieNow(object sender, Events.DieEventArgs e)
		{
			_timer.Stop();
			Buffer.Graphics.DrawString($"Game Over!\nDamage {e.LastDamage}", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.Red, 100, 100);
			Buffer.Render();
			_timer.Stop();
		}

		
	}
}
