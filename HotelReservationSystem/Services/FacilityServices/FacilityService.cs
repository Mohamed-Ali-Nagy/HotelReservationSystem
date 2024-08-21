using HotelReservationSystem.DTO.FacilityDTOs;
using HotelReservationSystem.Exceptions;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Models;
using HotelReservationSystem.Repositories;

namespace HotelReservationSystem.Services.FacilityServices
{
    public class FacilityService : IFacilityService
    {
        private readonly IRepository<Facility> _repository;
        public FacilityService(IRepository<Facility> repository)
        {
            _repository = repository;
        }
        public FacilityDTO Add(FacilityDTO facilityDTO)
        {
            var facility = _repository.Add(facilityDTO.MapOne<Facility>());
            _repository.SaveChanges();
            return facility.MapOne<FacilityDTO>();
    
        }

        public void Delete(int id)
        {
            var facility=GetByID(id);
            _repository.Delete(facility);
            _repository.SaveChanges();
        }

        public FacilityDTO Get(int id)
        {
            var facility=GetByID(id);
            return facility.MapOne<FacilityDTO>();
        }

        public IEnumerable<FacilityDTO> GetAll()
        {
           var facilities= _repository.GetAll();
            return facilities.Map<FacilityDTO>();
        }

        public void Update(FacilityUpdateDTO facilityDTO)
        {
            _repository.Update(facilityDTO.MapOne<Facility>());
            _repository.SaveChanges();
        }

        private Facility GetByID(int id)
        {
           var facility= _repository.GetByID(id);
            if(facility==null)
            {
                throw new BusinessException(ErrorCode.InvalidFacilityID, "Can not find facility with this ID");
            }
            return facility;
        }
    }
}
