using Booking.Entity;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.ViewModel
{
    public class UserViewModel : INotifyPropertyChanged
    {
        private User _user;

        public UserViewModel(User user)
        {
            _user = user;
        }

        public string JMBG
        {
            get => _user.JMBG;
            set
            {
                if(_user.JMBG != value)
                {
                    _user.JMBG = value;
                    OnPropertyChanged(nameof(JMBG));
                }
            }
        }

        public string Email
        {
            get => _user.Email;
            set
            {
                if(_user.Email != value)
                {
                    _user.Email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        public string FirstName
        {
            get => _user.FirstName;
            set
            {
                if(_user.FirstName != value)
                {
                    _user.FirstName = value;
                    OnPropertyChanged(nameof(FirstName));
                }
            }
        }

        public string LastName
        {
            get => _user.LastName;
            set
            {
                if(_user.LastName != value)
                {
                    _user.LastName = value;
                    OnPropertyChanged(nameof(LastName));
                }
            }
        }

        public string Phone
        {
            get => _user.Phone;
            set
            {
                if(_user.Phone != value)
                {
                    _user.Phone = value;
                    OnPropertyChanged(nameof(Phone));
                }
            }
        }

        public RolesEnum Role
        {
            get => _user.Role;
            set
            {
                if(_user.Role != value)
                {
                    _user.Role = value;
                    OnPropertyChanged(nameof(Role));
                }
            }
        }

        public bool Blocked
        {
            get => _user.Blocked;
            set
            {
                if(_user.Blocked != value)
                {
                    _user.Blocked = value;
                    OnPropertyChanged(nameof(Blocked));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
