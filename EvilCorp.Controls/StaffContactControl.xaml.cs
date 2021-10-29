using EvilCorp.Commun.EvilCorpService;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace EvilCorp.Controls
{
	/// <summary>
	/// Логика взаимодействия для StaffContactControl.xaml
	/// </summary>
	public partial class StaffContactControl : UserControl, INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private void NotifyPropertyChanged([CallerMemberName] string propertyName = "") //Позволяет получить имя свойства или метода вызывающего метод объекта.
		{
			if (PropertyChanged != null) // Если свойство не равно null
				PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName)); //Возбуждаем событие с заданным свойством
		}

		private Staff _staff;

		public Staff Staff
		{
			get { return _staff; }
			set
			{
				_staff = value;
				NotifyPropertyChanged();
			}
		}

		public ObservableCollection<StaffCategory> StaffList { get; set; } = new ObservableCollection<StaffCategory>();

		public StaffContactControl()
		{
			InitializeComponent();
			DataContext = this;
			StaffCategory();
			//cbCategory.ItemsSource = Enum.GetValues(typeof(StaffCategory)).Cast<StaffCategory>();
		}

		private void StaffCategory()
		{
			StaffList.Add(Commun.EvilCorpService.StaffCategory.Адвокат);
			StaffList.Add(Commun.EvilCorpService.StaffCategory.Вор);
			StaffList.Add(Commun.EvilCorpService.StaffCategory.Наемник);
			StaffList.Add(Commun.EvilCorpService.StaffCategory.Оружейник);
			StaffList.Add(Commun.EvilCorpService.StaffCategory.Телохранитель);
			StaffList.Add(Commun.EvilCorpService.StaffCategory.Убийца);
			StaffList.Add(Commun.EvilCorpService.StaffCategory.Раб);
		}



		//public void SetStuff(Staff staff)
		//{
		//	this.staff = staff;
		//	tbPhone.Text = staff.Phone;
		//	tbName.Text = staff.Name;
		//	tbLastName.Text = staff.LastName;
		//	tbSecondName.Text = staff.SecondName;
		//	tbComment.Text = staff.Comment;
		//	cbFreeNow.IsChecked = staff.FreeNow;
		//	cbCategory.SelectedItem = staff.Category;
		//}

		//public void UpdateStaff()
		//{
		//	staff.Phone = tbPhone.Text;
		//	staff.Name = tbName.Text;
		//	staff.LastName = tbLastName.Text;
		//	staff.SecondName = tbSecondName.Text;
		//	staff.Comment = tbComment.Text;
		//	staff.FreeNow = (bool)cbFreeNow.IsChecked;
		//	staff.Category = (StaffCategory)cbCategory.SelectedItem;
		//}
	}
}
