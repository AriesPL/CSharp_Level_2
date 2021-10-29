using EvilCorp.Commun.EvilCorpService;
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

		private void lvStaff_SelectionChanged(object sender, SelectionChangedEventArgs e) //Событие происходящее с листом персонала
		{
			if (e.AddedItems.Count != 0)
			{
				StaffControl.Staff = (Staff)SelectedStaff.Clone();
			}
		}

		private void btDelete_Click(object sender, RoutedEventArgs e) //Кнопка удаления
		{
			if (SelectedStaff == null) return;

			if (MessageBox.Show("Вы хотите его удалить?", "Удаление персонала.", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
			{
				if (_evilCorpDatabase.Remove(SelectedStaff) > 0)
				{
					//_evilCorpDatabase.Staffs.Remove(SelectedStaff);
					MessageBox.Show("Запись успешно удалена.", "Удаление записи", MessageBoxButton.OK, MessageBoxImage.Information);
					//UpdateList();
				}
			}

		}

		private void btUpdate_Click(object sender, RoutedEventArgs e) //Кнопка обновления
		{
			if (lvStaff.SelectedItems.Count < 1) return;
			if (_evilCorpDatabase.Update(SelectedStaff) > 0)
			{

				StaffList[StaffList.IndexOf(SelectedStaff)] = StaffControl.Staff;
				MessageBox.Show("Запись упешно обнавлена", "Обновление записи", MessageBoxButton.OK, MessageBoxImage.Information);
				//StaffControl.UpdateStaff();
				//UpdateList();
			}
		}

		private void btAddNew_Click(object sender, RoutedEventArgs e) //Кнопка добавления
		{
			StaffEditer staffEditer = new StaffEditer();
			if (staffEditer.ShowDialog() == true)
			{
				if (_evilCorpDatabase.Add(SelectedStaff) > 0)
				{

					_evilCorpDatabase.Staffs.Add(SelectedStaff);
				MessageBox.Show("Запись успешно добавлена.", "Добавление записи", MessageBoxButton.OK, MessageBoxImage.Information);
					//UpdateList();
				}
			}
		}

		//private void UpdateList()
		//{
		//	lvStaff.ItemsSource = null;
		//	lvStaff.ItemsSource = _evilCorpDatabase.Staffs;
		//}
	}
}
