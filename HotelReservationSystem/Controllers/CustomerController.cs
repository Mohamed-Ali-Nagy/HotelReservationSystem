using HotelReservationSystem.Mediators.FacilityMediators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HotelReservationSystem.ViewModels;
using HotelReservationSystem.ViewModels.FacilityViewModels;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.DTO.FacilityDTOs;
using HotelReservationSystem.Mediators.CustomerMediators;
using HotelReservationSystem.ViewModels.Customer;
using HotelReservationSystem.DTO.Customer;

namespace HotelReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        
        private readonly ICustomerMeditator _mediator;
        public CustomerController(ICustomerMeditator customerMediator)
        {
            _mediator = customerMediator;
        }
        [HttpGet("Get")]
        public IActionResult Get(int id)
        {
           var customerDTO = _mediator.Get(id);
            return Ok(ResultViewModel<CustomerViewModel>.Success(customerDTO.MapOne<CustomerDTO>()));
        }
        [HttpPost("Add")]
        public IActionResult Add(CustomerViewModel customerVM)
        {
            var customerDTO= _mediator.Add(customerVM.MapOne<CustomerDTO>());
            return Ok(ResultViewModel<CustomerViewModel>.Success(customerDTO.MapOne<CustomerViewModel>()));
        }

        [HttpPut("Update")]
        public IActionResult Update(CustomerViewModel customerVM)
        {
            _mediator.Update(customerVM.MapOne<CustomerDTO>());
            return Ok(ResultViewModel<bool>.Success(true));
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            _mediator.Delete(id);
            return Ok(ResultViewModel<bool>.Success(true));
        }
       
    }
}
