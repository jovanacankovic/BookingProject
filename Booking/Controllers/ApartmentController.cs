 using Booking.Services.Interfaces;
using Booking.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Booking.Controllers
{
    public class ApartmentController
    {
        private readonly IApartmentService _apartmentService;

        public ApartmentController(IApartmentService apartmentService)
        {
            this._apartmentService = apartmentService;
        }

        public void CreateAppartment(Apartment newApartment)
        {
            _apartmentService.CreateApartment(newApartment);
        }

        public IEnumerable<Apartment> GetAllApartments()
        {
            return this._apartmentService.GetAllApartments();
        }

        public Apartment GetApartmentByName(string ApartmentName)
        {
            return _apartmentService.GetApartmentByName(ApartmentName);
        }

        public void UpdateApartment(Apartment Apartment)
        {
            _apartmentService.UpdateApartment(Apartment);
        }

        public void DeleteApartment (string ApartmentName)
        {
            _apartmentService.DeleteApartmentByName(ApartmentName);
        }
    }
}
