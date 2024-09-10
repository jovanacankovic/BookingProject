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
        public AllUsersPage()
        {
            InitializeComponent();
        }

        private void btnApplyFilters_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBlock_Click(object sender, RoutedEventArgs e)
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

        private void dgReservations_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void dgUsers_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
