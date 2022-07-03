using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EvilCorp.Data
{
	public class Staff : INotifyPropertyChanged, ICloneable
	{
		//Событие делегата
		public event PropertyChangedEventHandler PropertyChanged;

		private string _phone;
		private string _name;
		private string _secondName;
		private string _lastName;
		private string _comment;
		private bool _freeNow;
		private StaffCategory _category = StaffCategory.Раб;
		
		private void NotifyPropertyChanged([CallerMemberName]string propertyName = "") //Позволяет получить имя свойства или метода вызывающего метод объекта.
		{
			if (PropertyChanged != null) // Если свойство не равно null
				PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName)); //Возбуждаем событие с заданным свойством
		}
		
		public object Clone()
		{
			return this.MemberwiseClone();
		}

		public string Phone
		{
			get { return _phone; }
			set 
			{ 
				_phone = value;
				NotifyPropertyChanged();
			}
		}

		public string Name
		{
			get { return _name; }
			set 
			{ 
				_name = value;
				NotifyPropertyChanged();
			}
		}
		public string SecondName
		{
			get { return _secondName; }
			set 
			{
				_secondName = value;
				NotifyPropertyChanged();
			}
		}
		public string LastName
		{
			get { return _lastName; }
			set 
			{
				_lastName = value;
				NotifyPropertyChanged();
			}
		}
		public string Comment
		{
			get { return _comment; }
			set 
			{
				_comment = value;
				NotifyPropertyChanged();
			}
		}
		public bool FreeNow
		{
			get { return _freeNow; }
			set 
			{
				_freeNow = value;
				NotifyPropertyChanged();
			}
		}
		public StaffCategory Category
		{
			get { return _category; }
			set 
			{
				_category = value;
				NotifyPropertyChanged();
			}
		}

		//public string FIO
		//{
		//	get { return $"{LastName} {Name} {SecondName}"; }
		//}
		public Staff() { }

		public Staff(string phone, string name, string secondname, string lastname, string comment, bool freenow, StaffCategory category)
		{
			Phone = phone;
			Name = name;
			SecondName = secondname;
			LastName = lastname;
			Comment = comment;
			FreeNow = freenow;
			Category = category;
		}


	}
}
