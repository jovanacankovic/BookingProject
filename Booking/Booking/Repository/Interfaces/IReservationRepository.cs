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
        IEnumerable<Reservation> FindAll(IEnumerable<Apartment> apartments);
        Reservation FindById(string id, IEnumerable<Apartment> apartments);
        Reservation CreateReservation(Reservation reservation);
        Reservation UpdateReservation(Reservation reservation);
        void DeleteReservationById(string id);
    }
}
