using Fleet_Management.DTO;

namespace Fleet_Management.Service
{
    public interface IAirportService
    {
        Task<List<AirportDTO>> GetAllAirportAsync();
        Task<AirportDTO> GetAirportByIdAsync(long id);
        Task<AirportDTO> GetAirportByCodeAsync(string airportCode);

    }
}
