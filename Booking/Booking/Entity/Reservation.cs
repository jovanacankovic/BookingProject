using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Entity
{
    public class Reservation
    {

        public String idReservation { get; set; }
        public DateTime date { get; set; }
        public User customer { get; set; }
        public ReservationStatusEnum status { get; set; } = ReservationStatusEnum.REQUESTED;
        public Apartment apartment { get; set; }
        public string ApartmentName { get; set; } = string.Empty;

        public string RefusedBecause;

    }
}
