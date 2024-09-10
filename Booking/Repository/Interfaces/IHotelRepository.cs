using Booking.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Repository.Interfaces
{
    public interface IHotelRepository
    {
        IEnumerable<Hotel> FindAll();
        IEnumerable<Hotel> GetAllHotels();
        IEnumerable<Hotel> ReadFromFileHotel();
        void WriteToFileHotel(IEnumerable<Hotel> hotels);
        Hotel FindById(int Id);
        Hotel CreateHotel(Hotel hotel);
        Hotel UpdateHotel(Hotel hotel);
        void DeleteHotelById(int Id);
    }
}
