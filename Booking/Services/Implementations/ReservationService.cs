using Booking.Entity;
using Booking.Repository.Interfaces;
using Booking.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Services.Implementations
{
    public class ReservationService : IReservationService
    {
        private IReservationRepository _reservationRepository;
        
        public ReservationService(IReservationRepository reservationRepository) 
        {
            this._reservationRepository = reservationRepository;
        }

        public void CancelReservation(string reservationId)
        {
            _reservationRepository.DeleteReservationById(reservationId);
        }

        public Reservation CreateReservation(Reservation Reservation)
        {
            return _reservationRepository.CreateReservation(Reservation);
        }

        public Reservation UpdateReservation(Reservation Reservation)
        {
            return _reservationRepository.UpdateReservation(Reservation);
        }

        public IEnumerable<Reservation> GetAllReservations()
        {
            return this._reservationRepository.GetAllReservations();
        }

    }
}
