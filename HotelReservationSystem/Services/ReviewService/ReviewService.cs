using HotelReservationSystem.DTO.Reservation;
using HotelReservationSystem.DTO.Review;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Models;
using HotelReservationSystem.Repositories;

namespace HotelReservationSystem.Services.ReviewService
{
    public class ReviewService : IReviewService
    {
        private readonly IRepository<Review> _repository;

        public ReviewService(IRepository<Review> repository)
        {
            _repository = repository;
        }
        public ReviewDTO Add(ReviewDTO reviewDTO)
        {
            Review review = _repository.Add(reviewDTO.MapOne<Review>());
            _repository.SaveChanges();
            return review.MapOne<ReviewDTO>();
        }

        public void Delete(ReviewDTO reviewDTO)
        {
            Review review = reviewDTO.MapOne<Review>();

            _repository.Delete(review);
            _repository.SaveChanges();
        }

        public IEnumerable<ReviewDTO> GetAll()
        {
            var Reviews = _repository.GetAll();

            return Reviews.Map<ReviewDTO>();
        }

        public ReviewDTO GetByID(int id)
        {
            var Reviews = _repository.GetByID(id);

            return Reviews.MapOne<ReviewDTO>();
        }

        public ReviewDTO Update(ReviewDTO reviewDTO)
        {
            Review review = reviewDTO.MapOne<Review>();

            Review returnReview = _repository.Update(review);
            _repository.SaveChanges();
            return returnReview.MapOne<ReviewDTO>();

        }
    }
}
