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

		static List<BaseGameObj> _asteroids;
		static BaseGameObj[] _stars;
		static BaseGameObj[] _comets;
		static List<Bullet> _bullets;
		static Ship _ship;

		public static int Widht { get; set; }
		public static int Height { get; set; }

		public static int Count = 0;

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
			_ship.DieNow += OnDieNow;
		}

		private static void Form_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Up) _ship.Up();
			if (e.KeyCode == Keys.Down) _ship.Down();
			if (e.KeyCode == Keys.ControlKey)
				if (_bullets.Count < 5)
				{
					_bullets.Add(new Bullet(new Point(_ship.Rect.X + 20, _ship.Rect.Y + 18), new Point(15, 0), new Size(74, 25)));
				}
		}

		private static void Timer_Tick(object sender, EventArgs e)
		{
			
			Draw();
			Update();
			if (_asteroids.Count == 0)
			{
				
				CreatedNewAsteroids(15 + Count);
				Count++;
			}

			if (_ship.Score % 10 == 0 && _ship.Score != 0)
				CreatedNewComets();
		}

		public static void Draw()// Отрисовка на форме
		{
			Buffer.Graphics.DrawImage(Resources.background, new Rectangle(0, 0, Widht, Height));

			//Отрисовка звезд
			foreach (BaseGameObj star in _stars)
			{
				star.Draw();
			}

			Buffer.Graphics.DrawImage(Resources.planet, new Rectangle(40, 40, 100, 100));

			//Отрисовка Астероидов
			foreach (BaseGameObj asteroid in _asteroids)
			{
				asteroid.Draw();
			}

			//Отрисовка Комет
			foreach (BaseGameObj comet in _comets)
			{
				if (comet != null) comet.Draw();
			}


			//отрисовка пуль
			foreach (var bullet in _bullets)
				bullet.Draw();

			//отрисовка карабля
			if (_ship != null)
			{
				_ship.Draw();
				Buffer.Graphics.DrawString($"Energy = {_ship.Energy}", SystemFonts.DefaultFont, Brushes.White, 0, 0);
				Buffer.Graphics.DrawString($"Score = {_ship.Score}", SystemFonts.DefaultFont, Brushes.White, 70, 0);
			}

			Buffer.Render();
		}

		public static void Update()//Обновление формы
		{
			//Звезды
			foreach (BaseGameObj star in _stars)
			{
				star.Update();
			}

			//Пули
			foreach (var bullet in _bullets)
			{
				bullet.Update();
			}


			//Астероиды
			for (int i = _asteroids.Count - 1; i >= 0; i--)
			{
				_asteroids[i].Update();
				bool asteroidDie = false;

				for (int j = _bullets.Count - 1; j >= 0; j--)
				{
					if (_asteroids[i].Collision(_bullets[j])) //Столкновение пули с астероидом
					{
						_bullets.Remove(_bullets[j]);
						_asteroids.Remove(_asteroids[i]);
						_ship.ScoreUp();
						asteroidDie = true;
						break;
					}
					if (_bullets[j].Rect.X > Widht) _bullets.Remove(_bullets[j]);

				}

				if (!asteroidDie && _ship.Collision(_asteroids[i])) //Столкновение коробля с астероидом
				{
					_asteroids.Remove(_asteroids[i]);
					_ship.EnergyLow(20);
					if (_ship.Energy <= 0)
					{
						_ship.Die();
					}
				}
				//Код работает, но временами выдает ошибку
				try
				{
					if (_asteroids[i].Rect.X < -100) _asteroids.Remove(_asteroids[i]);
				}
				catch (ArgumentException e)
				{
					Console.WriteLine($"Ошибка:{e}");
				}
			}

			//Кометы - Аптечки
			for (int i = 0; i < _comets.Length; i++)
			{
				if (_comets[i] == null) continue;

				_comets[i].Update();

				if (_comets[i] != null && _comets[i].Collision(_ship))
				{
					_comets[i] = null;
					if (_ship.Energy < 100) _ship.EnergyUp(70);
				}

			}


		}

		public static void Load()
		{

			_ship = new Ship(new Point(10, 300), new Point(5, 5), new Size(45, 60));

			_bullets = new List<Bullet>();

			_stars = new BaseGameObj[_random.Next(10, 20)];
			for (int i = 0; i < _stars.Length; i++)
			{
				int sizeStar = _random.Next(5, 25);
				_stars[i] = new Stars(new Point(_random.Next(1, 900), _random.Next(1, 450)), new Point(i, 1), new Size(sizeStar, sizeStar));
			}
			CreatedNewComets();

			CreatedNewAsteroids(15);
		}
		#region Созданиме комет.

		private static void CreatedNewComets()
		{
			_comets = new BaseGameObj[_random.Next(1, 2)];

			for (int i = 0; i < _comets.Length; i++)
			{
				_comets[i] = new Comets(new Point(_random.Next(20, 900), _random.Next(1, 450)), new Point(10, 1), new Size(40, 40));
			}
		}

		#endregion

		#region Создание астероидов.
		private static void CreatedNewAsteroids(int value)
		{
			_asteroids = new List<BaseGameObj>();
			for (int i = 0; i < value; i++)
			{
				int sizeAster = _random.Next(10, 100);
				_asteroids.Add(new Asteroids(new Point(_random.Next(880, 980), _random.Next(10, 350)), new Point(-i - 2, 0), new Size(sizeAster, sizeAster)));
			}
		}

		#endregion

		private static void OnDieNow(object sender, Events.DieEventArgs e)
		{
			_timer.Stop();
			Buffer.Graphics.DrawString($"Game Over!\nDamage {e.LastDamage}", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.Red, 100, 100);
			Buffer.Render();

		}


	}
}
