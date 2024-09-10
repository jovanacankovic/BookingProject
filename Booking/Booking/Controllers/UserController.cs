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

        public IEnumerable<User> FindAll()
        {
            return this.userService.FindAll();
        }

        public User RegisterUser(User user)
        {
            return this.userService.RegisterUser(user);
        }

        public void BlockUnblockUser(string userId)
        {
            userService.BlockUnblockUser(userId);
        }

        public void CreateUser(Entity.User User)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(Entity.User User)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(String username)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Entity.User GetOneUser(String username)
        {
            throw new NotImplementedException();
        }

    }
}
