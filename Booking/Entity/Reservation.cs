using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Entity
{
    public class Reservation
    {

        public String IdReservation { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        public ReservationStatusEnum Status { get; set; } = ReservationStatusEnum.REQUESTED;
        public string ApartmentName { get; set; }
        public string RefusedBecause { get; set; }

    }
}
