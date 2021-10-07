using Asteroid.GameObj;
using Asteroid.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
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
		static BaseGameObj[] _asteroids;
		static BaseGameObj[] _stars;
		static BaseGameObj[] _comets;
		static Bullet _bullet;

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

			Timer timer = new Timer();
			timer.Interval = 20;
			timer.Tick += Timer_Tick;

			timer.Start();

		}

		private static void Timer_Tick(object sender, EventArgs e)
		{
			Update();
			Draw();
		}

		public static void Draw()
		{
			Buffer.Graphics.DrawImage(Resources.background, new Rectangle(0, 0, Widht, Height));

			foreach(BaseGameObj star in _stars)
			{
				star.Draw();
			}
			
			Buffer.Graphics.DrawImage(Resources.planet, new Rectangle(40, 40, 100, 100));

			foreach (BaseGameObj asteroid in _asteroids)
			{
				asteroid.Draw();
			}

			foreach(BaseGameObj comet in _comets)
			{
				comet.Draw();
			}

			_bullet.Draw();

			Buffer.Render();
		}

		public static void Update()
		{
			foreach (BaseGameObj asteroid in _asteroids)
			{
				if (asteroid.Collision(_bullet))
				{
					_bullet = new Bullet(new Point(0, 300), new Point(5, 0), new Size(74, 25));
				}
				asteroid.Update();
			}

			foreach (BaseGameObj star in _stars)
			{
				star.Update();
			}
			foreach(BaseGameObj comet in _comets)
			{
				comet.Update();
			}
			
			_bullet.Update();
		}

		public static void Load()
		{
			Random random = new Random();
			_asteroids = new BaseGameObj[random.Next(5, 15)];
			_bullet = new Bullet(new Point(0, 300), new Point(5, 0), new Size(74, 25));

			for (int i = 0; i < _asteroids.Length; i++)
			{
				//int randomPos = random.Next(20, 980);
				int sizeAster = random.Next(10, 100);
				_asteroids[i] = new Asteroids(new Point(random.Next(20, 980), i*20+20), new Point(-i - 3,-i-3	), new Size(sizeAster, sizeAster));
			}

			_stars = new BaseGameObj[random.Next(20, 40)];
			for (int i = 0; i< _stars.Length;i++)
			{
				int sizeStar = random.Next(5, 25);
				_stars[i] = new Stars(new Point(random.Next(1, 980), random.Next(1, 500)), new Point(i, 1), new Size(sizeStar, sizeStar));
			}

			_comets = new BaseGameObj[2];
			for (int i = 0; i < _comets.Length; i++)
			{	

				_comets[i] = new Comets(new Point(random.Next(20, 980), random.Next(1, 500)), new Point(10, 1), new Size(40, 40));
			}

			
		}


	}
}
