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
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Map(m => m.JMBG).Name("JMBG");
            Map(m => m.Email).Name("Email");
            Map(m => m.Password).Name("Password");
            Map(m => m.FirstName).Name("FirstName");
            Map(m => m.LastName).Name("LastName");
            Map(m => m.Phone).Name("Phone").Default(string.Empty);
            Map(m => m.Role).Name("Role");
            Map(m => m.Blocked).Name("Blocked");
        }
    }
}
