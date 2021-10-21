using EvilCorp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EvilCorp
{
	/// <summary>
	/// Логика взаимодействия для StaffEditer.xaml
	/// </summary>
	public partial class StaffEditer : Window
	{

		public Staff Staff { get; set; } = new Staff();
		public StaffEditer()
		{
			InitializeComponent();
			staffControl.SetStuff(Staff);
		}

		private void btAddStuff_Click(object sender, RoutedEventArgs e)
		{
			staffControl.UpdateStaff();
			DialogResult = true;
		}

		private void btCansel_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}
