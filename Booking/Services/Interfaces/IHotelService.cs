using System;
using Booking.Entity;
using Booking.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Services.Interfaces
{
    public interface IHotelService
    {
        IEnumerable<Hotel> GetHotelsByOwnerId(string ownerId);
        IEnumerable<Hotel> GetAllHotels();
        void CreateHotel(Hotel hotel);
        void UpdateHotel(Hotel Hotel);
        IEnumerable<Hotel> FindNotVerified(string userId);
        void DeleteHotel(int hotelId);
    }
}
