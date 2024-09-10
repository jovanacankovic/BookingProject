using System;
using Booking.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Booking.Services.Interfaces;

namespace Booking.Controllers
{
    public class AuthenticationController
    {
        private readonly IAuthenticationService authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        public User LoginUser(string email, string password)
        {
            return authenticationService.LoginUser(email, password);
        }
    }
}
