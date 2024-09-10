using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Booking.Entity;
using Booking.Repository.Interfaces;
using Booking.Services.Interfaces;

namespace Booking.Services.Implementations
{
    public class ApartmentService : IApartmentService
    {
        private readonly IApartmentRepository _apartmentRepository;

        public ApartmentService(IApartmentRepository apartmentRepository)
        {
            this._apartmentRepository = apartmentRepository;
        }

        public void DeleteApartmentByName(string ApartmentName)
        {
            _apartmentRepository.DeleteApartmentByName(ApartmentName);
        }

        public Apartment GetApartmentByName(string ApartmentName)
        {
            return _apartmentRepository.GetApartmentByName(ApartmentName); 
        }

        public IEnumerable<Apartment> GetAllApartments()
        {
            return _apartmentRepository.GetAllApartments();
        }

        public IEnumerable<Apartment> ReadFromFileApartment()
        {
            return _apartmentRepository.ReadFromFileApartment();
        }

        public Apartment UpdateApartment(Apartment Apartment)
        {
            return _apartmentRepository.UpdateApartment(Apartment);
        }

        public void WriteToFileApartment(IEnumerable<Apartment> apartments)
        {
            _apartmentRepository.WriteToFileApartment(apartments);
        }

        Apartment IApartmentService.CreateApartment(Apartment Apartment)
        {
            return _apartmentRepository.CreateApartment(Apartment);
        }
    }
}
