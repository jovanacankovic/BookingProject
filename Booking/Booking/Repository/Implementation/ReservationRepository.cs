using Booking.Entity;
using Booking.Repository.Interfaces;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Repository.Implementation
{
    public class ReservationRepository : IReservationRepository
    {
        private const string filePath = "Booking\\Booking\\Booking\\Data\\reservations.csv";


        public Entity.Reservation CreateReservation(Entity.Reservation Reservation)
        {
            throw new NotImplementedException();
        }

        public Entity.Reservation UpdateReservation(Entity.Reservation Reservation)
        {
            throw new NotImplementedException();
        }

        public void DeleteReservationById(int reservation_id)
        {
            throw new NotImplementedException();
        }

        public List<Apartment> FindAll()
        {
            throw new NotImplementedException();
        }

        public Entity.Reservation FindById(int reservation_id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Reservation> IReservationRepository.FindAll(IEnumerable<Apartment> apartments)
        {
            throw new NotImplementedException();
        }

        Reservation IReservationRepository.FindById(string id, IEnumerable<Apartment> apartments)
        {
            throw new NotImplementedException();
        }

        void IReservationRepository.DeleteReservationById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
