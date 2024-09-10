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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private AuthenticationController controller;
        private int missedTries = 0;

        public User User { get; private set; }

        public LoginPage()
        {
            InitializeComponent();

            controller = new AuthenticationController(new AuthenticationService(new UserRepository()));
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var user = controller.LoginUser(txtEmail.Text, pbPassword.Password);

            if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(pbPassword.Password))
            {
                MessageBox.Show("All text fields should be filled", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (user == null)
            {
                MessageBox.Show("Username or password is not correct", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                missedTries++;

                if (missedTries == 3)
                {
                    MessageBox.Show("Maximum login attempts exceeded.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    App.Current.Shutdown();
                }

                return;
            }


            if (user.Role == RolesEnum.GUEST)
            {
                MessageBox.Show($"Welcome, {user.FirstName}! You are logged in as Guest!", "Welcome", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if (user.Role == RolesEnum.OWNER)
            {
                MessageBox.Show($"Welcome, {user.FirstName}! You are logged in as Owner!", "Welcome", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if (user.Role == RolesEnum.ADMIN)
            {
                MessageBox.Show($"Welcome, {user.FirstName}! You are logged in as Admin!", "Welcome", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                MessageBox.Show($"Welcome, {user.FirstName}! You are logged in as User!", "Welcome", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }


            MainWindow mainWindow = new MainWindow(user);
            mainWindow.Show();
           
            Window parentWindow = Window.GetWindow(this);

            if (parentWindow != null)
            {
                parentWindow.Close();
            }

        }


    }
}
