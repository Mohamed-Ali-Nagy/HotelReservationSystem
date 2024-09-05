using HotelReservationSystem.DTO.Payment;
using HotelReservationSystem.DTO.Room;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Mediators.Payment;
using HotelReservationSystem.Mediators.Room;
using HotelReservationSystem.ViewModels;
using HotelReservationSystem.ViewModels.Payment;
using HotelReservationSystem.ViewModels.Room;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentMediator _paymentMediator;

        public PaymentController(IPaymentMediator paymentMediator)
        {
            _paymentMediator = paymentMediator;
        }
        [HttpGet("Get")]
        public IActionResult Get(int pageNumber, int pageSize)
        {
            var roomResponseDTO= _paymentMediator.GetAll( pageNumber,  pageSize);
            return Ok(ResultViewModel<PaymentGetVM>.Success(roomResponseDTO.MapOne<PaymentGetVM>()));

        }

        [HttpPost("Add")]
        public IActionResult Add(PaymentCreateVM paymentCreateViewModel)
        {
            //var customers_Gateway=_paymentMediator.GetAllCustomers();

            var t=paymentCreateViewModel.MapOne<PaymentCreateDTO>();
            var paymentDTO = _paymentMediator.Add(t);
            var roomResponseVM= paymentDTO.MapOne<PaymentCreateVM>();
            return Ok(ResultViewModel<RoomResponseVM>.Success(roomResponseVM, "Room added successfully"));
        }

        [HttpPut("Update")]
        public IActionResult AssignReservation(int id, List<int> ReservationIds)
        {
            // var paymentDTO= paymentUpdateVM.MapOne<PaymentEditDTO>();
            _paymentMediator.AssignReservation(id, ReservationIds);
            return Ok(ResultViewModel<int>.Success(id));
        }

        [HttpDelete("Delete")]
        public IActionResult Cancel(int roomID)
        {
            _paymentMediator.Cancel(roomID);
            return Ok(ResultViewModel<bool>.Success(true,""));
        }


    }
}
