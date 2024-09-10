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
    public class AppartmentController
    {
        private readonly IApartmentService _apartmentService;

        public AppartmentController(IApartmentService apartmentService)
        {
            this._apartmentService = apartmentService;
        }

        public void CreateAppartment(Apartment Apartment)
        {
            Apartment existingApartment = _apartmentService.GetApartmentByName(Apartment.ApartmentName);
            if (existingApartment == null)
            {
                var newApartment = _apartmentService.CreateApartment(Apartment);
                MessageBox.Show($"New apartment created: {newApartment.ApartmentName}");
            }
            else
            {
                MessageBox.Show("Apartment with this name already exists. Use update instead.");
            }
        }

        public void UpdateApartment(Apartment Apartment)
        {
            Apartment existingApartment = _apartmentService.GetApartmentByName(Apartment.ApartmentName);
            if (existingApartment == null)
            {
                var updatedApartment = _apartmentService.UpdateApartment(Apartment);
                MessageBox.Show($"Apartment updated: {updatedApartment.ApartmentName}");
            }
            else
            {
                MessageBox.Show("No apartments with this name to update.");
            }
        }

        public void DeleteApartment (string ApartmentName)
        {
            _apartmentService.DeleteApartmentByName(ApartmentName);
            MessageBox.Show("Apartment deleted.");
        }
    }
}
