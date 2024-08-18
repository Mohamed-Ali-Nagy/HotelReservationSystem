using AutoMapper;
using HotelReservationSystem.DTO.Reservation;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Models;
using HotelReservationSystem.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystem.Services.ReservationServices
{
    public class ReservationService : IReservationService
    {
        
        IRepository<Reservation> _repository;

        public ReservationService(IRepository<Reservation> repository)
        {
            _repository = repository;
        }


        public IEnumerable<ReservationDTO> GetAll()
        {
            var Reservations = _repository.GetAll();

            return Reservations.Map<ReservationDTO>();
        }

        public ReservationDTO GetByID(int id)
        {
            var reservation = _repository.GetByID(id);

            return reservation.MapOne<ReservationDTO>();

        }


        public int Add(ReservationDTO reservationDTO)
        {
            var validReservation = ValidateReservation(reservationDTO);

            Reservation reservation = reservationDTO.MapOne<Reservation>();

            Reservation returnReservation = _repository.Add(reservation);

            try
            {
                _repository.SaveChanges();
            }
            catch (Exception ex)
            {

            }


            return returnReservation.ID;
        }

        private bool ValidateReservation(ReservationDTO reservationDTO)
        {
            if (reservationDTO.CheckIn > DateTime.Now 
                && reservationDTO.CheckOut > reservationDTO.CheckIn)
                return true;

            throw new Exception("Check In must be in the future and Check Out after Check In");
        }


        public ReservationDTO Update(ReservationDTO reservationDTO)
        {

            var validReservation = ValidateReservation(reservationDTO);

            Reservation reservation = reservationDTO.MapOne<Reservation>();

            Reservation returnReservation = _repository.Update(reservation);

            try
            {
                _repository.SaveChanges();
            }
            catch (Exception ex)
            {

            }


            return returnReservation.MapOne<ReservationDTO>();

        }


        public void Delete(ReservationDTO reservationDTO)
        {
            Reservation reservation = reservationDTO.MapOne<Reservation>();

            _repository.Delete(reservation);

            try
            {
                _repository.SaveChanges();
            }
            catch (Exception ex)
            {

            }

        }

        
    }
}
