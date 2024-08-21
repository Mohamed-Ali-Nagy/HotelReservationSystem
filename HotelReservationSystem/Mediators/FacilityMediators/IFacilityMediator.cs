using HotelReservationSystem.DTO.FacilityDTOs;

namespace HotelReservationSystem.Mediators.FacilityMediators
{
    public interface IFacilityMediator
    {
        public FacilityDTO Add(FacilityDTO facilityDTO);
        public void Update(FacilityUpdateDTO facilityDTO);
        public void Delete(int id);
        public FacilityDTO Get(int id);
        public IEnumerable<FacilityDTO> GetAll();
    }
}
