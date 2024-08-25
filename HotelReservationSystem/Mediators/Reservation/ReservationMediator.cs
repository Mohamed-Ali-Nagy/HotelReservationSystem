using HotelReservationSystem.DTO.Reservation;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Services.ReservationServices;
using HotelReservationSystem.Services.RoomServices;

namespace HotelReservationSystem.Mediators.Reservation
{
    public class ReservationMediator : IReservationMediator
    {
        IReservationService _reservationService;

        public ReservationMediator(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }
        public IEnumerable<ReservationDTO> GetAll()
        {
            var Reservations = _reservationService.GetAll();

            return Reservations;
        }

        public ReservationDTO GetByID(int id)
        {
            var reservation = _reservationService.GetByID(id);

            return reservation;

        }


        public int Add(ReservationDTO reservationDTO)
        {
           
            int reservationID = _reservationService.Add(reservationDTO);

            return reservationID;
        }


        


        public ReservationDTO Update(ReservationDTO reservationDTO)
        {

            ReservationDTO ReturnReservationDTO = _reservationService.Update(reservationDTO);

            return ReturnReservationDTO;

        }


        public void Delete(int ReservationID)
        {

            _reservationService.Delete(ReservationID);

        }
        
    }
}
