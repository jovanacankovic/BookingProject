using Booking.Repository.Interfaces;
using Booking.Services.Interfaces;
using Booking.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Services.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository userRepository;

        public AuthenticationService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public User LoginUser(String email, String password)
        {
            var user = userRepository.GetAllUsers().Where(x => x.Email.Equals(email) && x.Password.Equals(password) && !x.Blocked).FirstOrDefault();
            if (user is null)
            {
                return null;
            }
            return user;
        }
    }
}
