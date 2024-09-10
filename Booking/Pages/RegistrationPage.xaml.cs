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
    /// Interaction logic for RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        private UserController _userController;
        User user;

        public RegistrationPage(User loggedInUser)
        {
            InitializeComponent();

            _userController = new UserController(new UserService(new UserRepository()));
            user = loggedInUser;
        }

        //private const string DefaultPassword = "123";

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newUser = new User
                {
                    JMBG = txtJMBG.Text,
                    Email = txtEmail.Text,
                    FirstName = txtFisrtName.Text,
                    LastName = txtLastName.Text,
                    Password = pbPassword.Password,
                    Phone = txtPhone.Text,
                    Role = RolesEnum.OWNER,
                    Blocked = false
                };

                if (string.IsNullOrEmpty(newUser.JMBG) || string.IsNullOrEmpty(newUser.Email) || string.IsNullOrEmpty(newUser.FirstName) || string.IsNullOrEmpty(newUser.LastName) || string.IsNullOrEmpty(newUser.Phone))
                {
                    MessageBox.Show("Please fill all the fields correctly.", "Incomplete Data", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var existingUser = _userController.GetAllUsers().FirstOrDefault(u => u.JMBG == newUser.JMBG || u.Email == newUser.Email);
                if (existingUser != null)
                {
                    MessageBox.Show("A user with the same JMBG or email already exists.", "Duplicate Data", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                _userController.RegisterUser(newUser);

                MessageBox.Show("User registered successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Registration failed: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }


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
    }
}
