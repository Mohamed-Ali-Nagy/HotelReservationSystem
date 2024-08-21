using HotelReservationSystem.DTO.RoomFacilitiesDTOs;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Models;
using HotelReservationSystem.Repositories;

namespace HotelReservationSystem.Services.RoomFacilitiesServices
{
    public class RoomFacilitiesService
    {
        private readonly IRepository<RoomFacilities> _repository;
        public RoomFacilitiesService(IRepository<RoomFacilities> repository)
        {
            _repository = repository;
        }
        public RoomFacilityResponseDTO Add(RoomFacilityCreateDTO roomFacilityCreateDTO)
        {
           var roomFacility= _repository.Add(roomFacilityCreateDTO.MapOne<RoomFacilities>());
            _repository.SaveChanges();
            return roomFacility.MapOne<RoomFacilityResponseDTO>();
        }
        public void AddRange(List<RoomFacilityCreateDTO> roomFacilitiesDTO)
        {
            var roomFacilities=roomFacilitiesDTO.Select(r=>new RoomFacilities { FacilityID=r.FacilityID,RoomID=r.RoomID}).ToList();
            _repository.AddRange(roomFacilities);
        }
    }
}
