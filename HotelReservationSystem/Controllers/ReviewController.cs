using HotelReservationSystem.Mediators.ReviewMediators;
using HotelReservationSystem.ViewModels.FacilityViewModels;
using HotelReservationSystem.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HotelReservationSystem.ViewModels.Review;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.DTO.Review;
using HotelReservationSystem.DTO.FacilityDTOs;

namespace HotelReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly ReviewMeditator _reviewMeditator;

        public ReviewController(ReviewMeditator reviewMeditator)
        {
            _reviewMeditator = reviewMeditator;
        }
        [HttpGet("Get")]
        public IActionResult Get(int id)
        {
            ReviewDTO reviewDTO = _reviewMeditator.Get(id);
            return Ok(ResultViewModel<ReviewViewModel>.Success(reviewDTO.MapOne<ReviewViewModel>()));
        }
        [HttpPost("Add")]
        public IActionResult Add(ReviewViewModel reviewViewModel)
        {
            ReviewDTO reviewDTO = _reviewMeditator.Add(reviewViewModel.MapOne<ReviewDTO>());
            return Ok(ResultViewModel<FacilityVM>.Success(reviewDTO.MapOne<ReviewViewModel>()));
        }
        [HttpPut("Update")]
        public IActionResult Update(ReviewViewModel reviewViewModel)
        {
            _reviewMeditator.Update(reviewViewModel.MapOne<ReviewDTO>());
            return Ok(ResultViewModel<bool>.Success(true));
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            _reviewMeditator.Delete(id);
            return Ok(ResultViewModel<bool>.Success(true));
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var reviews = _reviewMeditator.GetAll();
            return Ok(ResultViewModel<List<ReviewViewModel>>.Success(reviews));
        }
    }
}
