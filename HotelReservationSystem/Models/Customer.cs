﻿namespace HotelReservationSystem.Models
{
    public class Customer : BaseModel
    {

        public string FullName { get; set; }
        public string Email { get; set; }

        public string? Braintree_ID { get; set; }

        public List<Reservation>? Reservation { get; set; }

    }
}
