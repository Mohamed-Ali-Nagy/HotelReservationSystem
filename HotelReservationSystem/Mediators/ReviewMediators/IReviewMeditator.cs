using HotelReservationSystem.DTO.FacilityDTOs;
using HotelReservationSystem.DTO.Review;

namespace HotelReservationSystem.Mediators.ReviewMediators
{
    public interface IReviewMeditator
    {
        public ReviewDTO Add(ReviewDTO reviewDTO);
        public void Update(ReviewDTO reviewDTO);
        public void Delete(int id);
        public ReviewDTO Get(int id);
        public IEnumerable<ReviewDTO> GetAll();
    }
}
