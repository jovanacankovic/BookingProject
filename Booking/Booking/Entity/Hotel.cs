using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Entity
{
    public class Hotel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int EstablishmentYear { get; set; }
        public int Stars { get; set; }
        public User Owner { get; set; }
        public bool Verified { get; set; }
        public string OwnerId { get; set; }
        public HashSet<Apartment> Apartments { get; set; }
    }
}
