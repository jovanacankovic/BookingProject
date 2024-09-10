using System;
using Booking.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Services.Interfaces
{
    public interface IUserService
    {
        void BlockUnblockUser(string userId);
        IEnumerable<User> FindAll();
        User RegisterUser(User user);
    }
}
