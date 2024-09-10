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
    /// Interaction logic for NewApartmentPage.xaml
    /// </summary>
    public partial class NewApartmentPage : Page
    {
        private ApartmentController _apartmentController;
        private HotelController _hotelController;
        private HotelRepository _hotelRepository;
        private ApartmentRepository _apartmentRepository;
        private List<Hotel> hotels;

        private User user;

        public NewApartmentPage(User loggedInUser)
        {
            InitializeComponent();

            _apartmentController = new ApartmentController(new ApartmentService(new ApartmentRepository()));
            _hotelController = new HotelController(new HotelService(new HotelRepository()));

            _hotelRepository = new HotelRepository();
            _apartmentRepository = new ApartmentRepository();
            hotels = new List<Hotel>();

            user = loggedInUser;

            LoadHotels();
            AddIdsToHotelComboBox();
        }

        private void LoadHotels()
        {
            try
            {
                hotels = _hotelController.GetAllHotels().ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load hotels: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddIdsToHotelComboBox()
        {
            try
            {
                var verifiedHotels = hotels.Where(h => h.Verified == true && h.OwnerId == user.JMBG).ToList();
                cbHotel.ItemsSource = verifiedHotels;
                cbHotel.DisplayMemberPath = "Id";
                cbHotel.SelectedValuePath = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load hotel Ids: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtNumberOfRooms.Text) || string.IsNullOrEmpty(txtMaxGuestNumber.Text) || string.IsNullOrEmpty(txtDescriptiom.Text) || cbHotel.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!int.TryParse(txtNumberOfRooms.Text, out int numberOfRooms) || numberOfRooms < 1 || numberOfRooms > 5)
            {
                MessageBox.Show("Number of rooms must be a number between 1 and 5.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!int.TryParse(txtMaxGuestNumber.Text, out int maxGuestNumber) || maxGuestNumber < 1 || maxGuestNumber > 10)
            {
                MessageBox.Show("Maximum number of guests must be a valid number between 1 and 10.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                Apartment newApartment = new Apartment
                {
                    ApartmentName = txtName.Text,
                    NumberOfRooms = int.Parse(txtNumberOfRooms.Text),
                    MaxNumberOfGuests = int.Parse(txtMaxGuestNumber.Text),
                    Description = txtDescriptiom.Text,
                    IdHotel = (int)cbHotel.SelectedValue
                };

                _apartmentController.CreateAppartment(newApartment);

                MessageBox.Show("Apartment successfully added!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);


                AllHotelsPage allHotelsWindow = new AllHotelsPage(user);
                Window parentWindow = Window.GetWindow(this);

                if (parentWindow != null)
                {
                    parentWindow.Content = allHotelsWindow;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save apartment: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
