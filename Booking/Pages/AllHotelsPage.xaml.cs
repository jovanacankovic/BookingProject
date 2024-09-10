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
using Booking.Controllers;
using Booking.Services.Implementations;

namespace Booking.Pages
{
    /// <summary>
    /// Interaction logic for AllHotelsPage.xaml
    /// </summary>
    public partial class AllHotelsPage : Page
    {
        private HotelController _hotelController;
        private ApartmentController _apartmentController;

        private List<Apartment> apartments;

        private User user;

        public AllHotelsPage(User loggedInUser)
        {
            InitializeComponent();

            _hotelController = new HotelController(new HotelService(new HotelRepository()));
            _apartmentController = new ApartmentController(new ApartmentService(new ApartmentRepository()));

            apartments = new List<Apartment>();

            user = loggedInUser;

            LoadHotels();
            LoadApartments();
        }

        private void LoadHotels()
        {
            try
            {
                List<Hotel> hotels = _hotelController.GetAllHotels().ToList();

                var verifiedHotels = hotels.Where(h => h.Verified == true).ToList();
                
                if (verifiedHotels != null && verifiedHotels.Count > 0)
                {
                    dgHotels.ItemsSource = verifiedHotels;
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

        private void LoadApartments()
        {
            try
            {
                apartments = _apartmentController.GetAllApartments().ToList();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load apartments: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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

        private void btnSort_Click(object sender, RoutedEventArgs e)
        {
            List<Hotel> hotels = _hotelController.GetAllHotels().Where(h => h.Verified).ToList();

            ComboBoxItem selectedCriteria = cbSortCriteria.SelectedItem as ComboBoxItem;
            if(selectedCriteria != null)
            {
                switch (selectedCriteria.Content.ToString())
                {
                    case "Sort by Name":
                        hotels = hotels.OrderBy(h => h.Name).ToList();
                        break;
                    case "Sort by Stars":
                        hotels = hotels.OrderByDescending(h => h.Stars).ToList();
                        break;
                    case "None":
                        break;
                    default:
                        MessageBox.Show("Please select a search criteria.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                }
            }

            dgHotels.ItemsSource = hotels;
        }

        private void cbSearchCriteria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tbSearch.Text = "";
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchValue = tbSearch.Text.ToLower();
            var selectedCriteria = (cbSearchCriteria.SelectedItem as ComboBoxItem)?.Content.ToString();
           
            List<Hotel> filteredHotels = _hotelController.GetAllHotels().Where(h => h.Verified).ToList();

            switch (selectedCriteria)
            {
                case "Search by Id":
                    if (int.TryParse(searchValue, out int id))
                    {
                        filteredHotels = filteredHotels.Where(h => h.Id == id).ToList();
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid numeric ID.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    break;
                case "Search by Name":
                    filteredHotels = filteredHotels.Where(h => h.Name.ToLower().Contains(searchValue)).ToList();
                    break;
                case "Search by Year":
                    if (int.TryParse(searchValue, out int year) && year >= 1900 && year <= 2024)
                    {
                        filteredHotels = filteredHotels.Where(h => h.EstablishmentYear == year).ToList();
                    }
                    else
                    {
                        MessageBox.Show("Invalid year input.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    break;
                case "Search by Stars":
                    if(int.TryParse(searchValue, out int stars) && stars >= 1 && stars <= 5)
                    {
                        filteredHotels = filteredHotels.Where(h => h.Stars == stars).ToList();
                    }
                    else
                    {
                        MessageBox.Show("Please enter a star rating between 1 and 5.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    break;
                case "None":
                    filteredHotels = filteredHotels.ToList();
                    break;
                default:
                    filteredHotels = filteredHotels.ToList();
                    MessageBox.Show("Please select a search criteria.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
            }

            if (filteredHotels.Any())
            {
                dgHotels.ItemsSource = filteredHotels;
            }
            else
            {
                MessageBox.Show("No hotels for this search criteria.", "No Results", MessageBoxButton.OK, MessageBoxImage.Information);
                dgHotels.ItemsSource = null;
            }
        }

        private void btnShowApartments_Click(object sender, RoutedEventArgs e)
        {
            if (dgHotels.SelectedItem is Hotel selectedHotel)
            {
                var hotelApartments = _apartmentController.GetAllApartments().Where(a => a.IdHotel == selectedHotel.Id).ToList();

                if (hotelApartments.Any())
                {
                    dgApartments.ItemsSource = hotelApartments;
                }
                else
                {
                    MessageBox.Show("No apartments found for the selected hotel.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    dgApartments.ItemsSource = null;
                }
            }
            else
            {
                var allApartments = _apartmentController.GetAllApartments();

                if (allApartments.Any())
                {
                    dgApartments.ItemsSource = allApartments;
                }
                else
                {
                    MessageBox.Show("No apartments found.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    dgApartments.ItemsSource = null;
                }
            }
          
        }

        private void btnShowHotel_Click(object sender, RoutedEventArgs e)
        {
            if (dgApartments.SelectedItem is Apartment selectedApartment)
            {
                var hotel = _hotelController.GetAllHotels().FirstOrDefault(h => h.Id == selectedApartment.IdHotel);

                if (hotel != null)
                {
                    dgHotels.ItemsSource = new List<Hotel> { hotel };
                }
                else
                {
                    MessageBox.Show("No hotel found for the selected apartment.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select an apartment first.", "Selection Required", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnRequestReservation_Click(object sender, RoutedEventArgs e)
        {

            if (dgApartments.SelectedItem is Apartment selectedApartment)
            {
                var reservationPage = new ApartmentReservationPage(user, selectedApartment);

                if (user.Role == RolesEnum.GUEST)
                {
                    ApartmentReservationPage apartmentReservationPage = new ApartmentReservationPage(user, selectedApartment);
                    Window parentWindow = Window.GetWindow(this);

                    if (parentWindow != null)
                    {
                        parentWindow.Content = apartmentReservationPage;
                    }
                }
                else
                {
                    MessageBox.Show("Only Guests can make reservations.", "Access Denied", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

            }
            else
            {
                MessageBox.Show("Please select an apartment first.", "No Apartment Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        private void btnSearchByApartments_Click(object sender, RoutedEventArgs e)
        {
            var apartments = _apartmentController.GetAllApartments();
            var hotels = _hotelController.GetAllHotels();
            List<Hotel> filteredHotels = new List<Hotel>();

            bool isRoomsEntered = int.TryParse(txtNumberOfRooms.Text, out int numberOfRooms);
            bool isGuestsEntered = int.TryParse(txtNumberOfGuests.Text, out int numberOfGuests);

            var selectedCriteria = (cbRoomsGuests.SelectedItem as ComboBoxItem)?.Content.ToString();

            switch (selectedCriteria)
            {
                case "Number of Rooms":
                    if (isRoomsEntered)
                    {
                        var matchingApartments = apartments.Where(a => a.NumberOfRooms == numberOfRooms).ToList();
                        filteredHotels = hotels.Where(h => matchingApartments.Any(a => a.IdHotel == h.Id)).ToList();

                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid number of rooms.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    break;

                case "Number of Guests":
                    if (isGuestsEntered)
                    {
                        var matchingApartments = apartments.Where(a => a.MaxNumberOfGuests == numberOfGuests).ToList();
                        filteredHotels = hotels.Where(h => matchingApartments.Any(a => a.IdHotel == h.Id)).ToList();
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid number of guests.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    break;

                case "Rooms and Guests":
                    if (isRoomsEntered && isGuestsEntered)
                    {
                        var matchingApatments = apartments.Where(a => a.NumberOfRooms == numberOfRooms && a.MaxNumberOfGuests == numberOfGuests).ToList();
                        filteredHotels = hotels.Where(h => matchingApatments.Any(a => a.IdHotel == h.Id)).ToList();
                    }
                    else
                    {
                        MessageBox.Show("Please enter valid values for both rooms and guests.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    break;

                case "Rooms or Guests":
                    if (isRoomsEntered || isGuestsEntered)
                    {
                        var matchingApatments = apartments.Where(a => a.NumberOfRooms == numberOfRooms || a.MaxNumberOfGuests == numberOfGuests).ToList();
                        filteredHotels = hotels.Where(h => matchingApatments.Any(a => a.IdHotel == h.Id)).ToList();
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid value for rooms or guests.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    break;

                default:
                    MessageBox.Show("Please select a valid search criteria.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;

            }

            if (filteredHotels.Any())
            {
                dgHotels.ItemsSource = filteredHotels;
            }
            else
            {
                MessageBox.Show("No hotels match the search criteria.", "No Results", MessageBoxButton.OK, MessageBoxImage.Information);
                dgHotels.ItemsSource = null;
            }
        }

        private void cbRoomsGuests_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtNumberOfRooms.Text = string.Empty;
            txtNumberOfGuests.Text = string.Empty;
        }
    }
}
