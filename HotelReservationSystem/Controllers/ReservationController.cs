using HotelReservationSystem.DTO.Reservation;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Mediators.Reservation;
using HotelReservationSystem.Services.ReservationServices;
using HotelReservationSystem.ViewModels.Reservation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {

        IReservationMediator _reservationMediator;

        public ReservationController(IReservationMediator reservationMediator)
        {
            _reservationMediator = reservationMediator;
        }



        [HttpGet]
        public IActionResult GetAll()
        {

            var Reservations = _reservationMediator.GetAll()
                .Select(x => x.MapOne<ReservationViewModel>());

            return Ok(Reservations);
        }



        [HttpGet("{ID:int}")]
        public IActionResult GetByID(int ID)
        {

            var reservation = _reservationMediator.GetByID(ID);

            var reservationViewModel = reservation.MapOne<ReservationViewModel>();

            return Ok(reservationViewModel);

        }



        [HttpPost]
        public IActionResult Add(ReservationViewModel reservationViewModel)
        {
            ReservationDTO reservationDTO = reservationViewModel.MapOne<ReservationDTO>();
            int ID = _reservationMediator.Add(reservationDTO);

            return Ok(ID);
        }



        [HttpPut]
        public IActionResult Update(ReservationViewModel reservationViewModel, int ID)
        {

            ReservationDTO reservationDTO = reservationViewModel.MapOne<ReservationDTO>();

            reservationDTO.ID = ID;

            ReservationDTO returnReservationDTO = _reservationMediator.Update(reservationDTO);

            return Ok(returnReservationDTO);

        }



        [HttpDelete]
        public IActionResult Delete(int ReservationID)
        {

            _reservationMediator.Delete(ReservationID);

            return Ok();

        }

    }
}
