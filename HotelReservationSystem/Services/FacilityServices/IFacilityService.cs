using HotelReservationSystem.DTO.FacilityDTOs;

namespace HotelReservationSystem.Services.FacilityServices
{
    public interface IFacilityService
    {
        public FacilityDTO Add(FacilityDTO facilityDTO);
        public void Update(FacilityUpdateDTO facilityDTO);
        public void Delete(int id);
        public FacilityDTO Get(int id);
        public IEnumerable<FacilityDTO> GetAll();
    }
}
