using Booking.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Services.Implementations
{
    public class ReservationService
    {
        public Entity.Reservation CreateReservation(ref Entity.Reservation Reservation)
        {
            throw new NotImplementedException();
        }

        public void AcceotReservation(ref int reservation_id)
        {
            throw new NotImplementedException();
        }

        public void RejectReservation(ref int reservation_id)
        {
            throw new NotImplementedException();
        }

        public void CancelReservation(ref int reservation_id)
        {
            throw new NotImplementedException();
        }

        public List<Reservation> FindReservationForUser(ref Entity.User User)
        {
            throw new NotImplementedException();
        }

        public List<Reservation> FindByApartmentId(ref int apartment_id)
        {
            throw new NotImplementedException();
        }
    }
}
