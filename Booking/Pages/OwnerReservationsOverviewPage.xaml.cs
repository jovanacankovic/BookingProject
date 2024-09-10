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
    /// Interaction logic for OwnerReservationsOverviewPage.xaml
    /// </summary>
    public partial class OwnerReservationsOverviewPage : Page
    {
        private ApartmentController _apartmentController;
        private ReservationController _reservationController;

        private User user;

        public OwnerReservationsOverviewPage(User loggedInUser)
        {
            InitializeComponent();
    
            _apartmentController = new ApartmentController(new ApartmentService(new ApartmentRepository()));
            _reservationController = new ReservationController(new ReservationService(new ReservationRepository()));

            user = loggedInUser;

            LoadReservations();
        }

        private void LoadReservations()
        {
            try
            {
                var hotels = new HotelRepository().GetAllHotels().Where(h => h.OwnerId == user.JMBG).ToList();

                var reservations = _reservationController.GetAllReservations().Where(r => hotels.Any(h => h.Id == _apartmentController.GetApartmentByName(r.ApartmentName).IdHotel)).Where(r => r.Status == ReservationStatusEnum.REQUESTED || r.Status == ReservationStatusEnum.ACCEPTED).ToList();
                
                if (reservations.Any())
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

        private void btnAcceptReservation_Click(object sender, RoutedEventArgs e)
        {
            if (dgReservations.SelectedItem is Reservation selectedReservation)
            {
                if (selectedReservation.Status == ReservationStatusEnum.REQUESTED)
                {
                    selectedReservation.Status = ReservationStatusEnum.ACCEPTED;
                    _reservationController.UpdateReservation(selectedReservation);
                    MessageBox.Show("Reservation accepted.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadReservations();
                }
                else
                {
                    MessageBox.Show("Only requested reservations can be accepted.", "Invalid Operation", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please select a reservation to accept.", "Selection Required", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnCancelReservation_Click(object sender, RoutedEventArgs e)
        {
            if (dgReservations.SelectedItem is Reservation selectedReservation)
            {
                if (selectedReservation.Status == ReservationStatusEnum.REQUESTED)
                {
                    if (string.IsNullOrWhiteSpace(txtRefusionReason.Text))
                    {
                        MessageBox.Show("Please provide a reason for cancellation.", "Input Required", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    selectedReservation.Status = ReservationStatusEnum.REJECTED;
                    selectedReservation.RefusedBecause = txtRefusionReason.Text;
                    _reservationController.UpdateReservation(selectedReservation);

                    MessageBox.Show("Reservation cancelled.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    
                    LoadReservations();
                    txtRefusionReason.Clear();
                }
                else
                {
                    MessageBox.Show("Only requested reservations can be cancelled.", "Invalid Operation", MessageBoxButton.OK, MessageBoxImage.Warning);

                }
            }
            else
            {
                MessageBox.Show("Please select a reservation to cancel.", "Selection Required", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            string filter = (cbReservationTypeFilter.SelectedItem as ComboBoxItem)?.Content.ToString();
            List<Reservation> filteredReservations = new List<Reservation>();

            var hotels = new HotelRepository().GetAllHotels().Where(h => h.OwnerId == user.JMBG).ToList();

            var reservations = _reservationController.GetAllReservations().Where(r => hotels.Any(h => h.Id == _apartmentController.GetApartmentByName(r.ApartmentName).IdHotel)).ToList();

            switch (filter)
            {
                case "Requested":
                    filteredReservations = reservations.Where(r => r.Status == ReservationStatusEnum.REQUESTED).ToList();
                    break;
                case "Accepted":
                    filteredReservations = reservations.Where(r => r.Status == ReservationStatusEnum.ACCEPTED).ToList();
                    break;
                case "All":
                    filteredReservations = reservations.Where(r => r.Status == ReservationStatusEnum.REQUESTED || r.Status == ReservationStatusEnum.ACCEPTED).ToList();
                    break;
                default:
                    filteredReservations = reservations.Where(r => r.Status == ReservationStatusEnum.REQUESTED || r.Status == ReservationStatusEnum.ACCEPTED).ToList();
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

        private void btnAllHotels_Click(object sender, RoutedEventArgs e)
        {
            AllHotelsPage allHotelsWindow = new AllHotelsPage(user);
            Window parentWindow = Window.GetWindow(this);

            if (parentWindow != null)
            {
                parentWindow.Content = allHotelsWindow;
            }
        }

        private void btnMyReservations_Click(object sender, RoutedEventArgs e)
        {
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
