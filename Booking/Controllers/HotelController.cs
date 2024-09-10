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
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            this._hotelService = hotelService;
        }

        public IEnumerable<Hotel> GetAllHotels()
        {
            return this._hotelService.GetAllHotels();
        }

        public void CreateHotel(Hotel hotel)
        {
            _hotelService.CreateHotel(hotel);
        }

        public IEnumerable<Hotel> FindNotVerified(User user)
        {
            return _hotelService.FindNotVerified(user.JMBG);
        }

        public void AcceptHotel(Hotel Hotel)
        {
            _hotelService.UpdateHotel(Hotel);
        }

        public void RejectHotel(int hotelId)
        {
            _hotelService.DeleteHotel(hotelId);
        }

    }
}
