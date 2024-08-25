using HotelReservationSystem.Mediators.FacilityMediators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HotelReservationSystem.ViewModels;
using HotelReservationSystem.ViewModels.FacilityViewModels;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.DTO.FacilityDTOs;

namespace HotelReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilityController : ControllerBase
    {
        
        private readonly IFacilityMediator _mediator;
        public FacilityController(IFacilityMediator facilityMediator)
        {
            _mediator = facilityMediator;
        }
        [HttpGet("Get")]
        public IActionResult Get(int id)
        {
           var facilityDTO= _mediator.Get(id);
            return Ok(ResultViewModel<FacilityVM>.Success(facilityDTO.MapOne<FacilityVM>()));
        }
        [HttpPost("Add")]
        public IActionResult Add(FacilityVM facilityVM)
        {
            var facilityDTO= _mediator.Add(facilityVM.MapOne<FacilityDTO>());
            return Ok(ResultViewModel<FacilityVM>.Success(facilityDTO.MapOne<FacilityVM>()));
        }

        [HttpPut("Update")]
        public IActionResult Update(FacilityUpdateVM facilityVM)
        {
            _mediator.Update(facilityVM.MapOne<FacilityUpdateDTO>());
            return Ok(ResultViewModel<bool>.Success(true));
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            _mediator.Delete(id);
            return Ok(ResultViewModel<bool>.Success(true));
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var facilities = _mediator.GetAll().Select(f => f.MapOne<FacilityVM>());
            return Ok(ResultViewModel<List<FacilityVM>>.Success(facilities));
        }
    }
}
