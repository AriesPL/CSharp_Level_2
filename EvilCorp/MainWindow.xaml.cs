using EvilCorp.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace EvilCorp
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private EvilCorpDatabase _evilCorpDatabase = new EvilCorpDatabase();

		public ObservableCollection<Staff> StaffList { get; set; }

		public Staff SelectedStaff { get; set; }

		public MainWindow()
		{
			InitializeComponent();
			DataContext = this;
			StaffList = _evilCorpDatabase.Staffs;
			//UpdateList();
		}
		
		private void lvStaff_SelectionChanged(object sender, SelectionChangedEventArgs e) //Событие происходящее с Ляистом персонала
		{
			if(e.AddedItems.Count != 0)
			{
				StaffControl.Staff = (Staff)SelectedStaff.Clone();
			}
		}

		private void btDelete_Click(object sender, RoutedEventArgs e) //Кнопка удаления
		{
			if (SelectedStaff == null) return;

			if (MessageBox.Show("Вы хотите его удалить?", "Удаление персонала.", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
			{
				_evilCorpDatabase.Staffs.Remove(SelectedStaff);
				//UpdateList();

			}
			
		}

		private void btUpdate_Click(object sender, RoutedEventArgs e) //Кнопка обновления
		{
			if (lvStaff.SelectedItems.Count < 1) return;
			StaffList[StaffList.IndexOf(SelectedStaff)] = StaffControl.Staff;
			//StaffControl.UpdateStaff();
			//UpdateList();
		}

		//private void UpdateList()
		//{
		//	lvStaff.ItemsSource = null;
		//	lvStaff.ItemsSource = _evilCorpDatabase.Staffs;
		//}

		private void btAddNew_Click(object sender, RoutedEventArgs e) //Кнопка добавления
		{
			StaffEditer staffEditer = new StaffEditer();
			if(staffEditer.ShowDialog() == true)
			{
				_evilCorpDatabase.Staffs.Add(staffEditer.Staff);
				//UpdateList();
			}
		}
	}
}
