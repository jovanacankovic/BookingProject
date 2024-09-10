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
    public class HotelRepository : IHotelRepository
    {
        private readonly string filePath = @"C:\Users\Pc\Desktop\Booking\Booking\Data\hotels.csv";
        public HotelRepository()
        {
            ReadFromFileHotel();
        }

        public IEnumerable<Hotel> ReadFromFileHotel()
        {
            var hotels = new List<Hotel>();

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<HotelMap>();
                hotels = csv.GetRecords<Hotel>().ToList();
            }

            return hotels;
        }

        public void WriteToFileHotel(IEnumerable<Hotel> hotels)
        {
            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                csv.WriteRecords(hotels);
        }

        public Hotel CreateHotel(Hotel hotel)
        {
            var hotels = GetAllHotels().ToList();

            if (hotels.Any(h => h.Id.Equals(hotel.Id)))
            {
                throw new ArgumentException("Id already exists.");
            }

            hotels.Add(hotel);
            WriteToFileHotel(hotels);
            return hotel;
        }

        public Hotel UpdateHotel(Hotel hotel)
        {
            var hotels = GetAllHotels().ToList();
            var existingHotel = hotels.FirstOrDefault(h => h.Id == hotel.Id);
            if (existingHotel != null)
            {
                hotels.Remove(existingHotel);
                hotels.Add(hotel);
                WriteToFileHotel(hotels);
            }
            return hotel;
        }

        public void DeleteHotelById(int hotel_id)
        {
            var hotels = GetAllHotels();
            var updateHotels = hotels.Where(h => h.Id != hotel_id).ToList();
            WriteToFileHotel(updateHotels);
        }

        public IEnumerable<Hotel> GetAllHotels()
        {
            return ReadFromFileHotel().ToList();
        }

        IEnumerable<Hotel> IHotelRepository.FindAll()
        {
            return ReadFromFileHotel().ToList();
        }

        Hotel IHotelRepository.FindById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
