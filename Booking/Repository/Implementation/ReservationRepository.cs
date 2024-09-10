using Booking.CsvConfiguration;
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
using System.Windows;

namespace Booking.Repository.Implementation
{
    public class ReservationRepository : IReservationRepository
    {
        private const string _filePath = @"C:\Users\Pc\Desktop\Booking\Booking\Data\reservations.csv";

        
        public ReservationRepository()
        {
            ReadFromFileReservation();
        }

        public IEnumerable<Reservation> ReadFromFileReservation()
        {
            var reservations = new List<Reservation>();

            using (var reader = new StreamReader(_filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<ReservationMap>();
                try
                {
                    reservations = csv.GetRecords<Reservation>().ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }

            return reservations;
        }

        public List<Reservation> GetAllReservations()
        {
            return ReadFromFileReservation().ToList();
        }


        public void WriteToFileReservation(IEnumerable<Reservation> reservations)
        {
            using (var writer = new StreamWriter(_filePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<ReservationMap>();
                csv.WriteRecords(reservations);
            }
        }


        public Reservation CreateReservation(Reservation Reservation)
        {
            var reservations = GetAllReservations().ToList();
            reservations.Add(Reservation);
            WriteToFileReservation(reservations);
            return Reservation;
        }

        public Reservation UpdateReservation(Reservation Reservation)
        {
            var reservations = GetAllReservations().ToList();
            var index = reservations.FindIndex(r => r.IdReservation == Reservation.IdReservation);

            if (index != -1)
            {
                reservations[index] = Reservation;
                WriteToFileReservation(reservations);
                return Reservation;
            }
            else
            {
                throw new Exception("Reservation not found");
            }
        }

        public void DeleteReservationById(string reservationId)
        {
            var reservations = GetAllReservations();
            var reservationToDelete = reservations.FirstOrDefault(r => r.IdReservation == reservationId);

            if (reservationToDelete != null)
            {
                reservations.Remove(reservationToDelete);
                WriteToFileReservation(reservations);
            }

        }


        Reservation IReservationRepository.FindById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("Reservation ID cannot be null or empty.", nameof(id));
            }
            return GetAllReservations().FirstOrDefault(r => r.IdReservation.Equals(id));
        }

    }
}
