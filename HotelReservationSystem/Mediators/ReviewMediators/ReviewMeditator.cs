using HotelReservationSystem.DTO.Review;
using HotelReservationSystem.Services.ReviewService;

namespace HotelReservationSystem.Mediators.ReviewMediators
{
    public class ReviewMeditator : IReviewMeditator
    {
        private readonly IReviewService _reviewService;

        public ReviewMeditator(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }
        public ReviewDTO Add(ReviewDTO reviewDTO)
        {
            return _reviewService.Add(reviewDTO);
        }

        public void Delete(int id)
        {
            ReviewDTO review = _reviewService.GetByID(id);
            _reviewService.Delete(review);
        }

        public ReviewDTO Get(int id)
        {
            return _reviewService.GetByID(id);
        }

        public IEnumerable<ReviewDTO> GetAll()
        {
            return _reviewService.GetAll();
        }

        public void Update(ReviewDTO reviewDTO)
        {
            _reviewService.Update(reviewDTO);
        }
    }
}
