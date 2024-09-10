using DocumentFormat.OpenXml.Office.Excel;
using System;
using Booking.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;

namespace Booking.CsvConfiguration
{
    public class HotelMap : ClassMap<Hotel>
    {
        public HotelMap() 
        {
            Map(m => m.Id).Name("Id");
            Map(m => m.Name).Name("Name");
            Map(m => m.EstablishmentYear).Name("EstablishmentYear");
            Map(m => m.Stars).Name("Stars");
            Map(m => m.Verified).Name("Verified");
            Map(m => m.OwnerId).Name("OwnerId");

           // References<UserMap>(m => m.Owner);
        }
    }
}
