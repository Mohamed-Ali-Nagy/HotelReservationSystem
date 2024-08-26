using HotelReservationSystem.DTO.Reservation;
using HotelReservationSystem.DTO.Review;

namespace HotelReservationSystem.Services.ReviewService
{
    public interface IReviewService
    {
        IEnumerable<ReviewDTO> GetAll();

        ReviewDTO GetByID(int id);

        ReviewDTO Add(ReviewDTO reviewDTO);

        ReviewDTO Update(ReviewDTO reviewDTO);

        void Delete(ReviewDTO reviewDTO);
    }
}
