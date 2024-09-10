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
        public OwnerReservationsOverviewPage()
        {
            InitializeComponent();
        }

        private void cbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dgReservations_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnAcceptReservation_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancelReservation_Click(object sender, RoutedEventArgs e)
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

        private void btnAllUsers_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRegisterUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnNewHotel_Click(object sender, RoutedEventArgs e)
        {

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
    }
}
