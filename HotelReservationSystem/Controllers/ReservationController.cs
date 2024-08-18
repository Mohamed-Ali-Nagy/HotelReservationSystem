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


        [HttpGet]
        public IActionResult GetByID(int id)
        {

            var reservation = _reservationService.GetByID(id);

            var reservationViewModel = reservation.MapOne<ReservationViewModel>();

            return Ok(reservationViewModel);

        }


        [HttpPost]
        public IActionResult Add(ReservationViewModel reservationViewModel)
        {
            ReservationDTO reservationDTO = reservationViewModel.MapOne<ReservationDTO>();
            int id = _reservationService.Add(reservationDTO);

            return Ok(id);
        }




    }
}
