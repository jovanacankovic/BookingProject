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
    /// Interaction logic for GuestReservationsPage.xaml
    /// </summary>
    public partial class GuestReservationsPage : Page
    {
        private ReservationController _reservationComtroller;

        private User user;

        public GuestReservationsPage(User loggedInUser)
        {
            InitializeComponent();

            _reservationComtroller = new ReservationController(new ReservationService(new ReservationRepository()));

            user = loggedInUser;

            LoadReservations();
        }

        private void LoadReservations()
        {
            try
            {
                List<Reservation> reservations = _reservationComtroller.GetAllReservations().Where(r => r.UserId == user.JMBG).ToList();
                
                if (reservations != null && reservations.Count > 0)
                {
                    dgReservations.ItemsSource = reservations;
                }
                else
                {
                    MessageBox.Show("No reservations found.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    dgReservations.ItemsSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load reservations: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {

            string filter = (cbReservationTypeFilter.SelectedItem as ComboBoxItem)?.Content.ToString();
            List<Reservation> filteredReservations = new List<Reservation>();

            var reservations = _reservationComtroller.GetAllReservations().Where(r => r.UserId == user.JMBG).ToList();

            switch (filter)
            {
                case "Requested":
                    filteredReservations = reservations.Where(r => r.Status == ReservationStatusEnum.REQUESTED).ToList();
                    break;
                case "Accepted":
                    filteredReservations = reservations.Where(r => r.Status == ReservationStatusEnum.ACCEPTED).ToList();
                    break;
                case "Rejected":
                    filteredReservations = reservations.Where(r => r.Status == ReservationStatusEnum.REJECTED).ToList();
                    break;
                case "All":
                    filteredReservations = reservations;
                    break;
                default:
                    filteredReservations = reservations;
                    break;
            }

            if (filteredReservations.Any())
            {
                dgReservations.ItemsSource = filteredReservations;
            }
            else
            {
                MessageBox.Show("No reservations found for the selected filter.", "No Results", MessageBoxButton.OK, MessageBoxImage.Information);
                dgReservations.ItemsSource = null;
            }
        }

        private void btnCancelReservation_Click(object sender, RoutedEventArgs e)
        {
            var selectedReservation = dgReservations.SelectedItem as Reservation;

            if (selectedReservation != null && (selectedReservation.Status == ReservationStatusEnum.REQUESTED || selectedReservation.Status == ReservationStatusEnum.ACCEPTED))
            {
                var result = MessageBox.Show("Are you sure you want to cancel this reservation?", "Confirm Cancellation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                
                if (result == MessageBoxResult.Yes)
                {
                    _reservationComtroller.CancelReservation(selectedReservation.IdReservation);
                    LoadReservations();
                    MessageBox.Show("Reservation has been cancelled successfully.", "Cancellation Successful", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Only requested or accepted reservations can be cancelled.", "Cancellation Not Allowed", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnAllHotels_Click(object sender, RoutedEventArgs e)
        {
            AllHotelsPage allHotelsWindow = new AllHotelsPage(user);
            Window parentWindow = Window.GetWindow(this);

            if (parentWindow != null)
            {
                parentWindow.Content = allHotelsWindow;
            }
        }

        private void btnReservationsOwner_Click(object sender, RoutedEventArgs e)
        {
            if (user.Role == RolesEnum.OWNER)
            {
                OwnerReservationsOverviewPage ownerReservationsWindow = new OwnerReservationsOverviewPage(user);
                Window parentWindow = Window.GetWindow(this);

                if (parentWindow != null)
                {
                    parentWindow.Content = ownerReservationsWindow;
                }
            }
            else
            {
                MessageBox.Show("Only Owners can access this page.", "Access Denied", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnAllUsers_Click(object sender, RoutedEventArgs e)
        {
            if (user.Role == RolesEnum.ADMIN)
            {
                AllUsersPage allUsersWindow = new AllUsersPage(user);
                Window parentWindow = Window.GetWindow(this);

                if (parentWindow != null)
                {
                    parentWindow.Content = allUsersWindow;
                }
            }
            else
            {
                MessageBox.Show("Only Admin can access this page.", "Access Denied", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnRegisterUser_Click(object sender, RoutedEventArgs e)
        {
            if (user.Role == RolesEnum.ADMIN)
            {
                RegistrationPage registrationWindow = new RegistrationPage(user);
                Window parentWindow = Window.GetWindow(this);

                if (parentWindow != null)
                {
                    parentWindow.Content = registrationWindow;
                }
            }
            else
            {
                MessageBox.Show("Only Admin can access this page.", "Access Denied", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnNewHotel_Click(object sender, RoutedEventArgs e)
        {
            if (user.Role == RolesEnum.ADMIN)
            {
                NewHotelPage newHotelWindow = new NewHotelPage(user);
                Window parentWindow = Window.GetWindow(this);

                if (parentWindow != null)
                {
                    parentWindow.Content = newHotelWindow;
                }
            }
            else
            {
                MessageBox.Show("Only Admin can access this page.", "Access Denied", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnPendingHotels_Click(object sender, RoutedEventArgs e)
        {
            if (user.Role == RolesEnum.OWNER)
            {
                PendingHotelsPage pendingHotelsWindow = new PendingHotelsPage(user);
                Window parentWindow = Window.GetWindow(this);

                if (parentWindow != null)
                {
                    parentWindow.Content = pendingHotelsWindow;
                }
            }
            else
            {
                MessageBox.Show("Only Owners can access this page.", "Access Denied", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnNewApartment_Click(object sender, RoutedEventArgs e)
        {
            if (user.Role == RolesEnum.OWNER)
            {
                NewApartmentPage newApartmentWindow = new NewApartmentPage(user);
                Window parentWindow = Window.GetWindow(this);

                if (parentWindow != null)
                {
                    parentWindow.Content = newApartmentWindow;
                }
            }
            else
            {
                MessageBox.Show("Only Owners can access this page.", "Access Denied", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            LoginPage loginWindow = new LoginPage();
            Window parentWindow = Window.GetWindow(this);

            if (parentWindow != null)
            {
                parentWindow.Content = loginWindow;
            }
        }

    }
}
