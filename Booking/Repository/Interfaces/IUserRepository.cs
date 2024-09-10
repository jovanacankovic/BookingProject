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
        List<User> GetAllUsers();
        IEnumerable<User> ReadFromFileUser();
        void WriteToFileUser(IEnumerable<User> users);
        User CreateUser(User user);
        User UpdateUser(User user);

    }
}
