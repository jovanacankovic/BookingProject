using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Booking;

namespace Booking.Entity
{
    public class User
    {

        public String JMBG { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Phone { get; set; }
        public RolesEnum Role { get; set; }
        public bool Blocked { get; set; }

        public System.Collections.ArrayList reservation;

        public User(string jmbg, string email, string password, string firstName, string lastName, string phone, RolesEnum role, bool blocked)
        {
            JMBG = jmbg;
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Role = role;
            Blocked = blocked;
        }

        /// <summary>
        /// Property for collection of Reservation
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        public System.Collections.ArrayList Reservation
        {
            get
            {
                if (reservation == null)
                    reservation = new System.Collections.ArrayList();
                return reservation;
            }
            set
            {
                RemoveAllReservation();
                if (value != null)
                {
                    foreach (Reservation oReservation in value)
                        AddReservation(oReservation);
                }
            }
        }

        /// <summary>
        /// Add a new Reservation in the collection
        /// </summary>
        /// <pdGenerated>Default Add</pdGenerated>
        public void AddReservation(Reservation newReservation)
        {
            if (newReservation == null)
                return;
            if (this.reservation == null)
                this.reservation = new System.Collections.ArrayList();
            if (!this.reservation.Contains(newReservation))
                this.reservation.Add(newReservation);
        }

        /// <summary>
        /// Remove an existing Reservation from the collection
        /// </summary>
        /// <pdGenerated>Default Remove</pdGenerated>
        public void RemoveReservation(Reservation oldReservation)
        {
            if (oldReservation == null)
                return;
            if (this.reservation != null)
                if (this.reservation.Contains(oldReservation))
                    this.reservation.Remove(oldReservation);
        }

        /// <summary>
        /// Remove all instances of Reservation from the collection
        /// </summary>
        /// <pdGenerated>Default removeAll</pdGenerated>
        public void RemoveAllReservation()
        {
            if (reservation != null)
                reservation.Clear();
        }
        public System.Collections.ArrayList hotel;

        /// <summary>
        /// Property for collection of Hotel
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        public System.Collections.ArrayList Hotel
        {
            get
            {
                if (hotel == null)
                    hotel = new System.Collections.ArrayList();
                return hotel;
            }
            set
            {
                RemoveAllHotel();
                if (value != null)
                {
                    foreach (Hotel oHotel in value)
                        AddHotel(oHotel);
                }
            }
        }

        /// <summary>
        /// Add a new Hotel in the collection
        /// </summary>
        /// <pdGenerated>Default Add</pdGenerated>
        public void AddHotel(Hotel newHotel)
        {
            if (newHotel == null)
                return;
            if (this.hotel == null)
                this.hotel = new System.Collections.ArrayList();
            if (!this.hotel.Contains(newHotel))
                this.hotel.Add(newHotel);
        }

        /// <summary>
        /// Remove an existing Hotel from the collection
        /// </summary>
        /// <pdGenerated>Default Remove</pdGenerated>
        public void RemoveHotel(Hotel oldHotel)
        {
            if (oldHotel == null)
                return;
            if (this.hotel != null)
                if (this.hotel.Contains(oldHotel))
                    this.hotel.Remove(oldHotel);
        }

        /// <summary>
        /// Remove all instances of Hotel from the collection
        /// </summary>
        /// <pdGenerated>Default removeAll</pdGenerated>
        public void RemoveAllHotel()
        {
            if (hotel != null)
                hotel.Clear();
        }
        
    }
}
