using Booking.Controllers;
using Booking.Entity;
using Booking.Repository.Implementation;
using Booking.Services.Implementations;
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

namespace Booking.Pages
{
    /// <summary>
    /// Interaction logic for ApartmentReservationPage.xaml
    /// </summary>
    public partial class ApartmentReservationPage : Page
    {
        private ReservationController _reservationController;

        User user;
        Apartment apartment;
        
        public ApartmentReservationPage(User loggedInUser, Apartment selectedApartment)
        {
            InitializeComponent();

            _reservationController = new ReservationController(new ReservationService(new ReservationRepository())/*, new HotelService(new HotelRepository())*/);

            user = loggedInUser;
            apartment = selectedApartment;
        }



        private void btnReserve_Click(object sender, RoutedEventArgs e)
        {
            if (dpDate.SelectedDate == null)
            {
                MessageBox.Show("Please select a date.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DateTime selectedDate = dpDate.SelectedDate.Value;

            if (selectedDate.Date <= DateTime.Now.Date)
            {
                MessageBox.Show("Reservation can only be made for future dates.", "Invalid Date", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var allReservations = _reservationController.GetAllReservations();

            bool isApartmentReserved = allReservations.Any(r => r.ApartmentName == apartment.ApartmentName && r.Date == selectedDate);

            if (isApartmentReserved)
            {
                MessageBox.Show("The apartment is already booked for this date.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Reservation newReservation = new Reservation
            {
                IdReservation = Guid.NewGuid().ToString(),
                Date = selectedDate,
                UserId = user.JMBG,
                ApartmentName = apartment.ApartmentName,
                Status = ReservationStatusEnum.REQUESTED
            };

            _reservationController.CreateReservation(newReservation);

            MessageBox.Show("Reservation successfully created! Waiting for owner's confirmation.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);


            if (user.Role == RolesEnum.GUEST)
            {
                GuestReservationsPage guestReservationsWindow = new GuestReservationsPage(user);
                Window parentWindow = Window.GetWindow(this);

                if (parentWindow != null)
                {
                    parentWindow.Content = guestReservationsWindow;
                }
            }
            else
            {
                MessageBox.Show("Only Guests can access this page.", "Access Denied", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

    }
}
