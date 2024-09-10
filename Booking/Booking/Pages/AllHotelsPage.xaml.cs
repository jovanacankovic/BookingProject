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
using Booking.Repository.Implementation;
using Booking.Entity;
using Booking.Repository.Interfaces;

namespace Booking.Pages
{
    /// <summary>
    /// Interaction logic for AllHotelsPage.xaml
    /// </summary>
    public partial class AllHotelsPage : Page
    {
        private HotelRepository _hotelRepository;

        public AllHotelsPage()
        {
            InitializeComponent();

            IUserRepository userRepository = new UserRepository();

            _hotelRepository = new HotelRepository(userRepository);

            LoadHotels();
        }

        private void LoadHotels()
        {
            try
            {
                List<Hotel> hotels = _hotelRepository.GetAllHotels();
                if (hotels != null && hotels.Count > 0)
                {
                    dgHotels.ItemsSource = hotels;
                }
                else
                {
                    MessageBox.Show("No hotels found.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    dgHotels.ItemsSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load hotels: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnMyReservations_Click(object sender, RoutedEventArgs e)
        {
            GuestReservationsPage guestReservationsWindow = new GuestReservationsPage();
            Window parentWindow = Window.GetWindow(this);

            if (parentWindow != null)
            {
                parentWindow.Content = guestReservationsWindow;
            }
        }

        private void btnReservationsOwner_Click(object sender, RoutedEventArgs e)
        {
            OwnerReservationsOverviewPage ownerReservationsWindow = new OwnerReservationsOverviewPage();
            Window parentWindow = Window.GetWindow(this);

            if (parentWindow != null)
            {
                parentWindow.Content = ownerReservationsWindow;
            }
        }

        private void btnAllUsers_Click(object sender, RoutedEventArgs e)
        {
            AllUsersPage allUsersWindow = new AllUsersPage();
            Window parentWindow = Window.GetWindow(this);

            if (parentWindow != null)
            {
                parentWindow.Content = allUsersWindow;
            }
        }

        private void btnRegisterUser_Click(object sender, RoutedEventArgs e)
        {
            Pages.RegistrationPage registrationWindow = new Pages.RegistrationPage();
            Window parentWindow = Window.GetWindow(this);

            if (parentWindow != null)
            {
                parentWindow.Content = registrationWindow;
            }
        }

        private void btnNewHotel_Click(object sender, RoutedEventArgs e)
        {
            NewHotelPage newHotelWindow = new NewHotelPage();
            Window parentWindow = Window.GetWindow(this);

            if (parentWindow != null)
            {
                parentWindow.Content = newHotelWindow;
            }
        }

        private void btnPendingHotels_Click(object sender, RoutedEventArgs e)
        {
            PendingHotelsPage pendingHotelsWindow = new PendingHotelsPage();
            Window parentWindow = Window.GetWindow(this);

            if (parentWindow != null)
            {
                parentWindow.Content = pendingHotelsWindow;
            }
        }

        private void btnNewApartment_Click(object sender, RoutedEventArgs e)
        {
            NewApartmentPage newApartmentWindow = new NewApartmentPage();
            Window parentWindow = Window.GetWindow(this);

            if (parentWindow != null)
            {
                parentWindow.Content = newApartmentWindow;
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

        private void btnSort_Click(object sender, RoutedEventArgs e)
        {
            //npr sortiraj po imenima
            /*
             List<Hotel> hotels = _hotelRepository.GetAllHotels();
            hotels.Sort((x, y) => x.Name.CompareTo(y.Name));
            dgHotels.ItemsSource = hotels;
             */
        }

        private void cbFilterCriteria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnShowApartments_Click(object sender, RoutedEventArgs e)
        {
            dgApartments.Visibility = dgApartments.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }
    }
}
