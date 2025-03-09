using Fleet_Management.Models;

namespace Fleet_Management.Service
{
    public interface IHubService
    {
        Task<List<HubDTO>> GetAllHubsAsync();
        Task<List<HubDTO>> GetHubsByCityIdAsync(long cityID);

        Task<HubDTO> GetHubsByAirportCodeAsync(string airportCode);
        
        // Task<HubMaster> GetHubsByCityNameAsync(string cityName);

    }
}
