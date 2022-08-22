
using AutoMapper;
using CoronaApp.Dal.Models;
using CoronaApp.Services;
using CoronaApp.Services.DTO;
using CoronaApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace CoronaApp.Dal
{
    public class LocationService : ILocationService
    {
        ILocationRepository _LocationRepository;
        private readonly IMapper _mapper;
        public LocationService(ILocationRepository LocationRepository, IMapper mapper)
        {
            _LocationRepository = LocationRepository;
            _mapper = mapper;
        }
        public async Task<List<Location>> getAllLocation()
        {
            return await _LocationRepository.getAllLocation();
        }
        public async Task<List<Location>> getLocationsByPatientId(string id)
        {
           return await _LocationRepository.getLocationsByPatientId(id);
          
        }
        public async Task<List<Location>> getLocationsByCity(string city)
        {
            return await _LocationRepository.getLocationsByCity(city);
        }
        public async Task<int> addNewLocation(PostLocationDTO newLocation)
        {
            Location location = _mapper.Map<Location>(newLocation);
            return await _LocationRepository.addNewLocation(location);
        }


        public async Task<List<Location>> getLocationsByLocationSaerch(LocationSearch locationSearch)
        {
            if(locationSearch.Age!=0 && locationSearch.StartDate != null && locationSearch.EndDate != null)
            {
                return await _LocationRepository.getLocationsByLocationSaerch(locationSearch);
            }
            if (locationSearch.Age != 0)
            {
                return await _LocationRepository.getLocationsByAge(locationSearch);
            }
            if (locationSearch.StartDate != null && locationSearch.EndDate != null)
            {
                return await _LocationRepository.getLocationsBetweenDates(locationSearch);
            }
            return null;
        }

        public async Task<bool> deleteLocation(int id)
        {
            return await _LocationRepository.deleteLocation(id);
        }
    }
}
