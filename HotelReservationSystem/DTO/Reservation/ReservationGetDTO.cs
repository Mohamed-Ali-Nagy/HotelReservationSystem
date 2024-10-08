﻿using HotelReservationSystem.Models;

namespace HotelReservationSystem.DTO.Reservation
{
    public class ReservationGetDTO
    {
        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public int RoomID { get; set; }

        public int CustomerID { get; set; }

    }
}
