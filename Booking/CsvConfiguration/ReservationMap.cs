using Booking.Entity;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.CsvConfiguration
{
    public class ReservationMap : ClassMap<Reservation>
    {
       public ReservationMap()
        {
            Map(m => m.IdReservation).Name("Id");
            Map(m => m.Date).Name("Date");
            Map(m => m.ApartmentName).Name("ApartmentName");
            Map(m => m.UserId).Name("GuestId");
            Map(m => m.Status).Name("Status");
            Map(m => m.RefusedBecause).Name("RefusedBecause").Optional();

        }
            
    }
}
