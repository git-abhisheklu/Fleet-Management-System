using Fleet_Management.Exceptions;
using Fleet_Management.Models;
using Fleet_Management.Repository;
using Microsoft.EntityFrameworkCore;

namespace Fleet_Management.Service
{
    public class AirportServiceImpl : IAirportService
    {
        private readonly FleetDbContext _fleetDbContext;

        public AirportServiceImpl(FleetDbContext fleetDbContext)
        {
            _fleetDbContext = fleetDbContext;
        }

        public async Task<AirportDTO> GetAirportByCodeAsync(string airportCode)
        {
                var airport = await _fleetDbContext.AirportMasters
                .Include(a => a.City)
                .ThenInclude(c => c.State)
                .Include(a => a.State)
                .Where(a => a.AirportCode == airportCode)
                .Select(a => new AirportDTO
                {
                    AirportId = a.AirportId,
                    AirportName = a.AirportName,
                    AirportCode = a.AirportCode,
                    City = new CityDTO
                    {
                        CityId = a.City.CityId,
                        CityName = a.City.CityName,
                        State = new StateDTO
                        {
                            StateId = a.City.State.StateId,
                            StateName = a.City.State.StateName
                        }
                    },
                    State = new StateDTO
                    {
                        StateId = a.State.StateId,
                        StateName = a.State.StateName
                    }
                })
                .FirstOrDefaultAsync();

            if (airport == null)
            {
                throw new ApiException($"Airport with code {airportCode} not found.");
            }

            return airport;
        }

        public async Task<AirportDTO> GetAirportByIdAsync(long id)
        {
            var airport = await _fleetDbContext.AirportMasters
            .Include(a => a.City)
            .ThenInclude(c => c.State)
            .Include(a => a.State)
            .Where(a => a.AirportId == id)
            .Select(a => new AirportDTO
            {
                AirportId = a.AirportId,
                AirportName = a.AirportName,
                AirportCode = a.AirportCode,
                City = new CityDTO
                {
                    CityId = a.City.CityId,
                    CityName = a.City.CityName,
                    State = new StateDTO
                    {
                        StateId = a.City.State.StateId,
                        StateName = a.City.State.StateName
                    }
                },
                State = new StateDTO
                {
                    StateId = a.State.StateId,
                    StateName = a.State.StateName
                }
            })
            .FirstOrDefaultAsync();

            if (airport == null)
            {
                throw new ApiException($"Airport with id {id} not found.");
            }

            return airport;
        }

        public async Task<List<AirportDTO>> GetAllAirportAsync()
        {
            return await _fleetDbContext.AirportMasters
        .Include(a => a.City)
        .ThenInclude(c => c.State)
        .Include(a => a.State)
        .Select(a => new AirportDTO
        {
            AirportId = a.AirportId,
            AirportName = a.AirportName,
            AirportCode = a.AirportCode,
            City = new CityDTO
            {
                CityId = a.City.CityId,
                CityName = a.City.CityName,
                State = new StateDTO
                {
                    StateId = a.City.State.StateId,
                    StateName = a.City.State.StateName
                }
            },
            State = new StateDTO
            {
                StateId = a.State.StateId,
                StateName = a.State.StateName
            }
        })
        .ToListAsync();
        }
    }

}
