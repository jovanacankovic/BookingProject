using Booking.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Services.Interfaces
{
    public interface IReservationService
    {
        void CancelReservation(string reservationId);
        Reservation CreateReservation(Reservation reservation);
        Reservation UpdateReservation(Reservation Reservation);
        IEnumerable<Reservation> GetAllReservations();

    }
}
