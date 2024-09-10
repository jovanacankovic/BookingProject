using Booking.Entity;
using Booking.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Booking.Repository.Interfaces;
using System.Globalization;
using System.IO;
using CsvHelper;
using DocumentFormat.OpenXml.Bibliography;
using Booking.CsvConfiguration;

namespace Booking.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private const string filePath = "C:\\Users\\Pc\\Desktop\\Booking\\Booking\\Booking\\Data\\users.csv";

        public IEnumerable<User> ReadFromFileUser()
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<UserMap>();
                var users = csv.GetRecords<User>().ToList();
                return users;
            }
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

        public Entity.User CreateUser(Entity.User User)
        {
            throw new NotImplementedException();
        }

        public Entity.User UpdateUser(Entity.User User)
        {
            throw new NotImplementedException();
        }

        public void DeleteUserByJMBG(String JMBG)
        {
            throw new NotImplementedException();
        }

        public List<User> FindAll()
        {
            throw new NotImplementedException();
        }

        public Entity.User FindByJMBG(String JMBG)
        {
            throw new NotImplementedException();
        }

        IEnumerable<User> IUserRepository.FindAll()
        {
            return ReadFromFileUser();
        }
    }
}
