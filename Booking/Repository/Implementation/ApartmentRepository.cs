using Booking.CsvConfiguration;
using Booking.Entity;
using Booking.Repository.Interfaces;
using CsvHelper;
using DocumentFormat.OpenXml.Bibliography;
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
    public class ApartmentRepository : IApartmentRepository
    {
        private const string _filePath = @"C:\Users\Pc\Desktop\Booking\Booking\Data\apartments.csv";
        

        public ApartmentRepository()
        {
            ReadFromFileApartment();
        }

        public IEnumerable<Apartment> ReadFromFileApartment()
        {
            var apartments  = new List<Apartment>();
            using (var reader = new StreamReader(_filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<ApartmentMap>();
                try
                {
                    apartments = csv.GetRecords<Apartment>().ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }

            return apartments;
        }

        public IEnumerable<Apartment> GetAllApartments()
        {
            var hotels = new HotelRepository().GetAllHotels();
            var apartments = ReadFromFileApartment().ToList();

            foreach (var apartment in apartments)
            {
                var hotel = hotels.FirstOrDefault(h => h.Id == apartment.IdHotel);
                if (hotel != null)
                {
                    apartment.OwnerId = hotel.OwnerId;
                }
            }

            return apartments;
        }

        public void WriteToFileApartment(IEnumerable<Apartment> apartments)
        {
            using (var writer = new StreamWriter(_filePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<ApartmentMap>();
                csv.WriteRecords(apartments);
            }
        }

        public Apartment CreateApartment(Apartment Apartment)
        {
            var apartments = ReadFromFileApartment().ToList();
            if (apartments.Any(a => a.ApartmentName.ToLower().Equals(Apartment.ApartmentName.ToLower())))
            {
                throw new ArgumentException("Name already exists.");
            }
            apartments.Add(Apartment);
            WriteToFileApartment(apartments);
            return Apartment;
        }

        public Apartment UpdateApartment(Apartment Apartment)
        {
            var apartments = ReadFromFileApartment().ToList();
            var existingApartment = apartments.FirstOrDefault(a => a.ApartmentName == Apartment.ApartmentName);
            if (existingApartment != null)
            {
                existingApartment.MaxNumberOfGuests = Apartment.MaxNumberOfGuests;
                existingApartment.NumberOfRooms = Apartment.NumberOfRooms;
                existingApartment.Description = Apartment.Description;
                WriteToFileApartment(apartments);
                return existingApartment;
            }
            return null;
        }

        public Apartment GetApartmentByName(String ApartmentName)
        {
            var apartments = ReadFromFileApartment();
            return apartments.FirstOrDefault(a => a.ApartmentName == ApartmentName);
        }

        public void DeleteApartmentByName(string ApartmentName)
        {
            var apartments = ReadFromFileApartment().ToList();
            apartments.RemoveAll(a => a.ApartmentName == ApartmentName);
            WriteToFileApartment(apartments);
        }

    }
}
