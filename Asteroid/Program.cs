using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
 * 1: Добавить класс кометы.
 * 2: Изменить обьекты на картинки.
 */

namespace Asteroid
{
	static class Program
	{
		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Form form = new Form();
			form.MinimumSize = new System.Drawing.Size(1000, 500);
			form.MaximumSize = new System.Drawing.Size(1000, 500);
			form.MinimizeBox = false;
			form.MaximizeBox = false;
			form.StartPosition = FormStartPosition.CenterScreen;
			form.Text = "Astro";

			GameOpt.Init(form);
			

			Application.Run(form);

		}
	}
}
