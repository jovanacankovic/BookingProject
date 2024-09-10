using Booking.Entity;
using Booking.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.ViewModel
{
    public class ApartmentViewModel : INotifyPropertyChanged
    {

        private readonly IApartmentService _apartmentService;
        public ObservableCollection<Apartment> Apartments { get; private set; }

        public ApartmentViewModel(IApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
            Apartments = new ObservableCollection<Apartment>(_apartmentService.ReadFromFileApartment());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
