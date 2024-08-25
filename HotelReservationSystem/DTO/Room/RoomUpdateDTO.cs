﻿using HotelReservationSystem.Models;

namespace HotelReservationSystem.DTO.Room
{
    public class RoomUpdateDTO
    {
        public int ID { get; set; }
        public RoomType roomType { get; set; }
        public LuxuryLevel luxuryLevel { get; set; }

        public double Price { get; set; }
    }
}