using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Entity
{
    public class Apartment
    {

        public string ApartmentName { get; set; }
        public string Description { get; set; }
        public int NumberOfRooms { get; set; }
        public int MaxNumberOfGuests { get; set; }

        public Hotel hotel { get; set; }

        public Hotel Hotel
        {
            get
            {
                return hotel;
            }
            set
            {
                this.hotel = value;
            }
        }
    }
}
