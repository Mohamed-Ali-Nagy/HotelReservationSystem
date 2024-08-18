using HotelReservationSystem.DTO.Reservation;
using HotelReservationSystem.Helpers;
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

        IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }



        [HttpGet]
        public IActionResult GetAll()
        {

            var Reservations = _reservationService.GetAll()
                .Select(x => x.MapOne<ReservationViewModel>());

            return Ok(Reservations);
        }



        [HttpGet("{ID:int}")]
        public IActionResult GetByID(int ID)
        {

            var reservation = _reservationService.GetByID(ID);

            var reservationViewModel = reservation.MapOne<ReservationViewModel>();

            return Ok(reservationViewModel);

        }



        [HttpPost]
        public IActionResult Add(ReservationViewModel reservationViewModel)
        {
            ReservationDTO reservationDTO = reservationViewModel.MapOne<ReservationDTO>();
            int ID = _reservationService.Add(reservationDTO);

            return Ok(ID);
        }



        [HttpPut]
        public IActionResult Update(ReservationViewModel reservationViewModel, int ID)
        {

            ReservationDTO reservationDTO = reservationViewModel.MapOne<ReservationDTO>();

            reservationDTO.ID = ID;

            ReservationDTO returnReservationDTO = _reservationService.Update(reservationDTO);

            return Ok(returnReservationDTO);

        }



        [HttpDelete]
        public IActionResult Delete(int ID)
        {

            ReservationDTO reservationDTO = _reservationService.GetByID(ID);

            _reservationService.Delete(reservationDTO);

            return Ok();

        }

    }
}
