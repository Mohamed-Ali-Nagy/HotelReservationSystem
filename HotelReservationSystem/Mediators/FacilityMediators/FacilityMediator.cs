using HotelReservationSystem.DTO.FacilityDTOs;
using HotelReservationSystem.Services.FacilityServices;

namespace HotelReservationSystem.Mediators.FacilityMediators
{
    public class FacilityMediator : IFacilityMediator
    {
        private readonly IFacilityService _facilityService;
        public FacilityMediator(IFacilityService facilityService)
        {
            _facilityService = facilityService;
        }
        public FacilityDTO Add(FacilityDTO facilityDTO)
        {
           return _facilityService.Add(facilityDTO);
        }

        public void Delete(int id)
        {
            _facilityService.Delete(id);
        }

        public FacilityDTO Get(int id)
        {
            return _facilityService.Get(id);
        }

        public IEnumerable<FacilityDTO> GetAll()
        {
            return _facilityService.GetAll().ToList();
        }

        public void Update(FacilityUpdateDTO facilityDTO)
        {
           _facilityService.Update(facilityDTO);
        }
    }
}
