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

namespace Booking.Repository.Implementation
{
    public class HotelRepository : IHotelRepository
    {
        private readonly IUserRepository _userRepository;

        private readonly string filePath = "Booking\\Booking\\Booking\\Data\\hotels.csv";
        //private readonly string userFilePath = "Booking\\Booking\\Booking\\Data\\users.csv";

        public HotelRepository(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<Hotel> ReadFromFileHotel()
        {
            var hotels = new List<Hotel>();
            var users = _userRepository.FindAll().ToList();

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<HotelMap>();
                hotels = csv.GetRecords<Hotel>().ToList();
            }

            foreach (var hotel in hotels)
            {
                hotel.Owner = users.FirstOrDefault(user => user.JMBG == hotel.OwnerId);
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
            var hotels = GetAllHotels();
            hotels.Add(hotel);
            WriteToFileHotel(hotels);
            return hotel;
        }

        public Hotel UpdateHotel(Hotel hotel)
        {
            var hotels = GetAllHotels();
            var existingHotel = hotels.FirstOrDefault(h => h.Id == hotel.Id);
            if (existingHotel != null)
            {
                hotels.Remove(existingHotel);
                hotels.Add(hotel);
                WriteToFileHotel(hotels);
            }
            return hotel;
        }

        public void DeleteHotelById(ref int hotel_id)
        {
            throw new NotImplementedException();
        }

        public List<Hotel> GetAllHotels()
        {
            return ReadFromFileHotel().ToList();
        }

        public Entity.Hotel GetHotelById(ref int hotel_id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Hotel> IHotelRepository.FindAll()
        {
            return ReadFromFileHotel().ToList();
        }

        Hotel IHotelRepository.FindById(int Id)
        {
            throw new NotImplementedException();
        }

        void IHotelRepository.DeleteHotelById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
