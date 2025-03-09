using Fleet_Management.Models;

namespace Fleet_Management.Service
{
    public interface ICityService
    {
        Task<List<CityDTO>> GetCitiesByStateAsync(long stateId);

        // Task<List<CityMaster>> GetCitiesByStateNameAsync(string stateName);
    }

}
