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
        IEnumerable<Hotel> SearchHotels(HotelFilterCriteria filter, HotelSortCriteria sort, ApartmentFilterCriteria apartmentFilter, string searchingText);
        IEnumerable<Hotel> GetHotelsByOwnerId(string ownerId);
        void CreateHotel(Hotel hotel);
        IEnumerable<Hotel> FindNotVerified(string userId);
        void VerifyHotel(string hotelId);
        void RejectHotel(string hotelId);
    }
}
