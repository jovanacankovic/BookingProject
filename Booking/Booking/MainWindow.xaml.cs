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
        public MainWindow()
        {
            InitializeComponent();
           // MainFrame.NavigationService.Navigate(new Pages.LoginPage());
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

        private void btnAllHotels_Click(object sender, RoutedEventArgs e)
        {
            AllHotelsPage allHotelsWindow = new AllHotelsPage();
            Window parentWindow = Window.GetWindow(this);

            if(parentWindow != null)
            {
                parentWindow.Content = allHotelsWindow;
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

        private void mainFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {

        }
    }
}
