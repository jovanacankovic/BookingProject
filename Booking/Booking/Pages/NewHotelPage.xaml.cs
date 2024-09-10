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
    /// Interaction logic for NewHotelPage.xaml
    /// </summary>
    public partial class NewHotelPage : Page
    {
        public NewHotelPage()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAllHotels_Click(object sender, RoutedEventArgs e)
        {
            AllHotelsPage allHotelsWindow = new AllHotelsPage();
            Window parentWindow = Window.GetWindow(this);

            if (parentWindow != null)
            {
                parentWindow.Content = allHotelsWindow;
            }
        }

        private void btnMyReservations_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnReservationsOwner_Click(object sender, RoutedEventArgs e)
        {

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

        private void btnPendingHotels_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnNewApartment_Click(object sender, RoutedEventArgs e)
        {

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
