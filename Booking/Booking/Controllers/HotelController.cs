using Booking.Entity;
using Booking.Services.Interfaces;
using Booking.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Controllers
{
    public class HotelController
    {
        private readonly IHotelService hotelService;

        public HotelController(IHotelService hotelService)
        {
            this.hotelService = hotelService;
        }

        public IEnumerable<Hotel> SearchHotels(HotelFilterCriteria filter, HotelSortCriteria sort, ApartmentFilterCriteria apartmentFilter, string searchingText)
        {
            return hotelService.SearchHotels(filter, sort, apartmentFilter, searchingText);
        }

        public void CreateHotel(Hotel hotel)
        {
            hotelService.CreateHotel(hotel);
        }

        public IEnumerable<Hotel> FindNotVerified(User user)
        {
            return hotelService.FindNotVerified(user.JMBG);
        }

        public void UpdateHotel(Entity.Hotel Hotel)
        {
            throw new NotImplementedException();
        }

        public void DeleteHotel(int hotel_id)
        {
            throw new NotImplementedException();
        }

        public List<Hotel> GetAllHotels()
        {
            throw new NotImplementedException();
        }

        public void AcceptHotel(string hotelId)
        {
            hotelService.VerifyHotel(hotelId);
        }

        public void RejectHotel(string hotelId)
        {
            hotelService.RejectHotel(hotelId);
        }

        public IEnumerable<Hotel> GetByOwner(string JMBG)
        {
            return hotelService.GetHotelsByOwnerId(JMBG);
        }
    }
}
