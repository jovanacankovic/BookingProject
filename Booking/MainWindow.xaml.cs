using Booking.Entity;
using Booking.Pages;
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

namespace Booking
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private User user;

        public MainWindow(User loggedInUser)
        {
            InitializeComponent();
            // MainFrame.NavigationService.Navigate(new Pages.LoginPage());
            user = loggedInUser;
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

        private void btnAllHotels_Click(object sender, RoutedEventArgs e)
        {
            AllHotelsPage allHotelsWindow = new AllHotelsPage(user);
            Window parentWindow = Window.GetWindow(this);

            if(parentWindow != null)
            {
                parentWindow.Content = allHotelsWindow;
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

        private void mainFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {

        }
    }
}
