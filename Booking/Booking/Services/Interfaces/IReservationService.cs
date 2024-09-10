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
        void AcceptReservation(string reservationId);
        void RejectReservation(string reservationId, string reason);
        void CancelReservation(string reservationId);
        Reservation CreateReservation(Reservation reservation);
        IEnumerable<Reservation> FindByApartmentsIds(IEnumerable<string> apartmentNames);
        IEnumerable<Reservation> FindReservationsForUser(User user);
    }
}
