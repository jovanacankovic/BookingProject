using Booking.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Repository.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> FindAll();
        IEnumerable<User> ReadFromFileUser();
        void WriteToFileUser(IEnumerable<User> users);
        User FindByJMBG(string JMBG);

        User CreateUser(User user);

        User UpdateUser(User user);

        void DeleteUserByJMBG(string JMBG);
    }
}
