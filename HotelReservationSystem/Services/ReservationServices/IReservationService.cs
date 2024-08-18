using HotelReservationSystem.DTO.Reservation;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.Services.ReservationServices
{
    public interface IReservationService
    {
        
        IEnumerable<ReservationDTO> GetAll();

        ReservationDTO GetByID(int id);

        int Add(ReservationDTO reservationDTO);

        ReservationDTO Update(ReservationDTO reservationDTO);

        void Delete(ReservationDTO reservationDTO);

    }
}
