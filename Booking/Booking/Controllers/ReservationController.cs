using Booking.Entity;
using Booking.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Controllers
{
    public class ReservationController
    {
        private readonly IReservationService reservationService;
        private readonly IHotelService hotelService;

        public ReservationController(IReservationService reservationService, IHotelService hotelService)
        {
            this.reservationService = reservationService;
            this.hotelService = hotelService;
        }

        public Reservation CreateReservation(Reservation reservation)
        {
            return reservationService.CreateReservation(reservation);
        }

        public void CancelReservation(string reservationdId)
        {
            reservationService.CancelReservation(reservationdId);
        }

        public IEnumerable<Reservation> FindReservationForOwner(User user)
        {
            //var hotels = hotelService.GetHotelsByOwnerId(user.JMBG);
            //var apartments = hotels.SelectMany(h => h.Apartments).Select(a => a.name);
            //var reservations = reservationService.FindByApartmentsIds(name);
            //return reservations;
            throw new NotImplementedException();
        }

        public IEnumerable<Reservation> FindReservationForUser(User user)
        {
            return reservationService.FindReservationsForUser(user);
        }

        public void AcceptReservation(string reservationId)
        {
            reservationService.AcceptReservation(reservationId);
        }

        public void RejectReservation(string reservationId, string reason)
        {
            reservationService.RejectReservation(reservationId, reason);
        }
    }
}
