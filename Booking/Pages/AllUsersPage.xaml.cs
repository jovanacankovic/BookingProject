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
    /// Interaction logic for AllUsersPage.xaml
    /// </summary>
    public partial class AllUsersPage : Page
    {
        private UserController _userController;

        private User user;

        public AllUsersPage(User loggedInUser)
        {
            InitializeComponent();

            _userController = new UserController(new UserService(new UserRepository()));

            user = loggedInUser;

            LoadUsers();
        }

        private void LoadUsers()
        {
            try
            {
                List<User> users = (List<User>)_userController.GetAllUsers();
                if (users != null && users.Count > 0)
                {
                    dgUsers.ItemsSource = users;
                }
                else
                {
                    MessageBox.Show("No hotels found.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    dgUsers.ItemsSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load hotels: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        private void btnBlock_Click(object sender, RoutedEventArgs e)
        {
            var selectedUser = dgUsers.SelectedItem as User;

            if (selectedUser != null)
            {
                selectedUser.Blocked = !selectedUser.Blocked;
                _userController.BlockUnblockUser(selectedUser);

                dgUsers.Items.Refresh();

                MessageBox.Show($"User {(selectedUser.Blocked ? "blocked" : "unblocked")}", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Please select a user to block/unblock.", "Selection Needed", MessageBoxButton.OK, MessageBoxImage.Warning);
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
            var users = _userController.GetAllUsers();
            string sortCriteria = (cbSort.SelectedItem as ComboBoxItem)?.Content.ToString();

            switch (sortCriteria)
            {
                case "Sort by First Name (asc)":
                    users = users.OrderBy(u => u.FirstName).ToList();
                    break;
                case "Sort by First Name (desc)":
                    users = users.OrderByDescending(u => u.FirstName).ToList();
                    break;
                case "Sort by Last Name (asc)":
                    users = users.OrderBy(u => u.LastName).ToList();
                    break;
                case "Sort by Last Name (desc)":
                    users = users.OrderByDescending(u => u.LastName).ToList();
                    break;
                case "None":
                    users = _userController.GetAllUsers().ToList();
                    break;
                default:
                    users = _userController.GetAllUsers().ToList();
                    break;
            }

            dgUsers.ItemsSource = users;
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            var users = _userController.GetAllUsers();
            string filterType = (cbUserTypeFilter.SelectedItem as ComboBoxItem)?.Content.ToString();

            switch (filterType)
            {
                case "All":
                    users = _userController.GetAllUsers().ToList();
                    break;
                case "Guest":
                    users = users.Where(u => u.Role == RolesEnum.GUEST).ToList();
                    break;
                case "Owner":
                    users = users.Where(u => u.Role == RolesEnum.OWNER).ToList();
                    break;
                default:
                    users = _userController.GetAllUsers().ToList();
                    break;
            }

            dgUsers.ItemsSource = users;

        }
    }
}
