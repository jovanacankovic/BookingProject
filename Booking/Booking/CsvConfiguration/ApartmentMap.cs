using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Booking.Entity;
using CsvHelper.Configuration;
using DocumentFormat.OpenXml.Spreadsheet;

namespace Booking.CsvConfiguration
{
    public class ApartmentMap : ClassMap<Apartment>
    {
        public ApartmentMap()
        {
            Map(m => m.ApartmentName).Name("ApartmentName");
            Map(m => m.MaxNumberOfGuests).Name("MaxNumberOfGuests");
            Map(m => m.NumberOfRooms).Name("NumberOfRooms");
            Map(m => m.Description).Name("Description");
        }
    }
}
