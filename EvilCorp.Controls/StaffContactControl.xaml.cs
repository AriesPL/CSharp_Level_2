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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EvilCorp.Controls
{
	/// <summary>
	/// Логика взаимодействия для StaffContactControl.xaml
	/// </summary>
	public partial class StaffContactControl : UserControl
	{
		private Staff staff;
		public StaffContactControl()
		{
			InitializeComponent();

			cbCategory.ItemsSource = Enum.GetValues(typeof(StaffCategory)).Cast<StaffCategory>();
		}

		public void SetStuff(Staff staff)
		{
			this.staff = staff;
			tbPhone.Text = staff.Phone;
			tbName.Text = staff.Name;
			tbLastName.Text = staff.LastName;
			tbSecondName.Text = staff.SecondName;
			tbComment.Text = staff.Comment;
			cbFreeNow.IsChecked = staff.FreeNow;
			cbCategory.SelectedItem = staff.Category;
		}

		public void UpdateStaff()
		{
			staff.Phone = tbPhone.Text;
			staff.Name = tbName.Text;
			staff.LastName = tbLastName.Text;
			staff.SecondName = tbSecondName.Text;
			staff.Comment = tbComment.Text;
			staff.FreeNow = (bool)cbFreeNow.IsChecked;
			staff.Category = (StaffCategory)cbCategory.SelectedItem;
		}
	}
}
