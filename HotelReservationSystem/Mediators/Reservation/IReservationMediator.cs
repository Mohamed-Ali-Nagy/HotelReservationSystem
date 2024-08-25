using HotelReservationSystem.DTO.Reservation;
using HotelReservationSystem.DTO.Room;

namespace HotelReservationSystem.Mediators.Reservation
{
    public interface IReservationMediator
    {

        IEnumerable<ReservationDTO> GetAll();

        ReservationDTO GetByID(int id);

        int Add(ReservationDTO reservationDTO);

        ReservationDTO Update(ReservationDTO reservationDTO);

        void Delete(int ReservationID);

    }
}
