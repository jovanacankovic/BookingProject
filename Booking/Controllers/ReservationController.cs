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
        private IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            this._reservationService = reservationService;
        }

        public Reservation CreateReservation(Reservation reservation)
        {
            return _reservationService.CreateReservation(reservation);
        }

        public void CancelReservation(string reservationdId)
        {
            _reservationService.CancelReservation(reservationdId);
        }

        public IEnumerable<Reservation> GetAllReservations()
        {
            return this._reservationService.GetAllReservations();
        }

        public Reservation UpdateReservation(Reservation Reservation)
        {
            return _reservationService.UpdateReservation(Reservation);
        }
    }
}
