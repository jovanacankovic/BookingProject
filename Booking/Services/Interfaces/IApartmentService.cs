using System;
using Booking.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Services.Interfaces
{
    public interface IApartmentService
    {

        IEnumerable<Apartment> ReadFromFileApartment();
        void WriteToFileApartment(IEnumerable<Apartment> apartments);
        IEnumerable<Apartment> GetAllApartments();
        Apartment GetApartmentByName(string ApartmentName);
        Apartment CreateApartment(Apartment Apartment);
        Apartment UpdateApartment(Apartment Apartment);
        void DeleteApartmentByName(string ApartmentName);

    }
}
