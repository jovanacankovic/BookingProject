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
    /// Interaction logic for PendingHotelsPage.xaml
    /// </summary>
    public partial class PendingHotelsPage : Page
    {
        public PendingHotelsPage()
        {
            InitializeComponent();
        }

        private void dgHotels_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnAcceptHotel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRejectHotel_Click(object sender, RoutedEventArgs e)
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
            OwnerReservationsOverviewPage ownerReservationsWindow = new OwnerReservationsOverviewPage();
            Window parentWindow = Window.GetWindow(this);

            if (parentWindow != null)
            {
                parentWindow.Content = ownerReservationsWindow;
            }
        }

        private void btnAllUsers_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRegisterUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnNewHotel_Click(object sender, RoutedEventArgs e)
        {

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
    }
}
