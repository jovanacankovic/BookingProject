using Booking.Entity;
using Booking.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;
using CsvHelper;
using DocumentFormat.OpenXml.Bibliography;
using Booking.CsvConfiguration;
using System.Windows;

namespace Booking.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly string filePath = @"C:\Users\Pc\Desktop\Booking\Booking\Data\users.csv";

        public UserRepository()
        {
            ReadFromFileUser();
        }

        public IEnumerable<User> ReadFromFileUser()
        {
            var users = new List<User>();

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<UserMap>();
                try
                {
                    users = csv.GetRecords<User>().ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }


            return users;
        }

        public void WriteToFileUser(IEnumerable<User> users)
        {
            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<UserMap>();
                csv.WriteRecords(users);
            }
        }

        public User CreateUser(User User)
        {
            var users = GetAllUsers().ToList();

            if (users.Any(u => u.JMBG == User.JMBG || u.Email == User.Email))
            {
                throw new Exception("User with the same JMBG or Email already exists.");
            }

            users.Add(User);
            WriteToFileUser(users);
            return User;
        }

        public User UpdateUser(User User)
        {
            var users = ReadFromFileUser();
            var user = users.FirstOrDefault(u => u.JMBG == User.JMBG);

            if (user != null)
            {
                user.Email = User.Email;
                user.Password = User.Password;
                user.FirstName = User.FirstName;
                user.LastName = User.LastName;
                user.Phone = User.Phone;
                user.Role = User.Role;
                user.Blocked = User.Blocked;

                WriteToFileUser(users);
                return user;
            }
            else
            {
                throw new ArgumentException("User not found");
            }
        }

         public List<User> GetAllUsers()
        {
            return ReadFromFileUser().ToList();
        }

    }
}
