using Booking.Entity;
using Booking.Repository.Interfaces;
using Booking.Services.Interfaces;
using Booking.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Services.Implementations
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelService(IHotelRepository hotelRepository)
        {
            this._hotelRepository = hotelRepository;
        }

        public void CreateHotel(Hotel Hotel)
        {
            _hotelRepository.CreateHotel(Hotel);
        }

        public void UpdateHotel(Hotel Hotel)
        {
            _hotelRepository.UpdateHotel(Hotel);
        }

        public IEnumerable<Hotel> FindNotVerified(string userId)
        {
            return _hotelRepository.FindAll().Where(h => h.OwnerId == userId && h.Verified == false);
        }

        public IEnumerable<Hotel> GetHotelsByOwnerId(string ownerId)
        {
            var hotels = _hotelRepository.FindAll().Where(h => h.Verified);
            foreach (var hotel in hotels)
            {
                if (hotel.OwnerId == ownerId) yield return hotel;
            }
        }

        public IEnumerable<Hotel> GetAllHotels()
        {
            return _hotelRepository.GetAllHotels();
        }

        public void DeleteHotel(int hotelId)
        {
            _hotelRepository.DeleteHotelById(hotelId);
        }

    }
}
