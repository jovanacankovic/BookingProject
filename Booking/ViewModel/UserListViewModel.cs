using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.ViewModel
{
    public class UserListViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<UserListViewModel> _users = new ObservableCollection<UserListViewModel>();

        public ObservableCollection<UserListViewModel> Users
        {
            get { return _users; }
            set 
            {
                _users = value;
                OnPropertyChanged(nameof(Users));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
