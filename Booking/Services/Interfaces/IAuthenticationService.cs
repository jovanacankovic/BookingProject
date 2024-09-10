using Booking.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Services.Interfaces
{
    public interface IAuthenticationService
    {
        User LoginUser(string email, string password);
    }
}
