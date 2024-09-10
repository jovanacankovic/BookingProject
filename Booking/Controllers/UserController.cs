using Booking.Entity;
using Booking.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Controllers
{
    public class UserController
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return this.userService.GetAllUsers();
        }

        public User RegisterUser(User user)
        {
            return this.userService.RegisterUser(user);
        }

        public User BlockUnblockUser(User user)
        {
            return this.userService.BlockUnblockUser(user);
        }

    }
}
