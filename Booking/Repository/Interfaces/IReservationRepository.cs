using System;
using Booking.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Packaging;

namespace Booking.Repository.Interfaces
{
    public interface IReservationRepository
    {
        IEnumerable<Reservation> ReadFromFileReservation();
        void WriteToFileReservation(IEnumerable<Reservation> reservations);
        List<Reservation> GetAllReservations();
        Reservation FindById(string reservationId);
        Reservation CreateReservation(Reservation reservation);
        Reservation UpdateReservation(Reservation reservation);
        void DeleteReservationById(string reservationId);
    }
}
