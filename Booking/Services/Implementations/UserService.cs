using Booking.Entity;
using Booking.Repository.Interfaces;
using Booking.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Booking.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
       
        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public User RegisterUser(User user)
        {
            return _userRepository.CreateUser(user);
        }

        public User BlockUnblockUser(User user)
        {
            return _userRepository.UpdateUser(user);
        }

    }
}
