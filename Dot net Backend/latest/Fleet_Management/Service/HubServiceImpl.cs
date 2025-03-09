using Fleet_Management.Models;
using Fleet_Management.Repository;
using Microsoft.EntityFrameworkCore;

namespace Fleet_Management.Service
{
    public class HubServiceImpl : IHubService
    {
        private readonly FleetDbContext _fleetDbContext;

        public HubServiceImpl(FleetDbContext fleetDbContext)
        {
            _fleetDbContext = fleetDbContext;
        }

        public async Task<List<HubDTO>> GetAllHubsAsync()
        {
            return await _fleetDbContext.HubMasters
        .Select(h => new HubDTO
        {
            HubId = h.HubId,
            ContactNumber = h.ContactNumber,
            HubAddress = h.HubAddress,
            HubName = h.HubName,
            Airport = h.Airport == null ? null : new AirportDTO
            {
                AirportId = h.Airport.AirportId,
                AirportName = h.Airport.AirportName,
                AirportCode = h.Airport.AirportCode,
                City = h.Airport.City == null ? null : new CityDTO
                {
                    CityId = h.Airport.City.CityId,
                    CityName = h.Airport.City.CityName,
                    State = h.Airport.City.State == null ? null : new StateDTO
                    {
                        StateId = h.Airport.City.State.StateId,
                        StateName = h.Airport.City.State.StateName
                    }
                },
                State = h.Airport.State == null ? null : new StateDTO
                {
                    StateId = h.Airport.State.StateId,
                    StateName = h.Airport.State.StateName
                }
            },
            City = h.City == null ? null : new CityDTO
            {
                CityId = h.City.CityId,
                CityName = h.City.CityName,
                State = h.City.State == null ? null : new StateDTO
                {
                    StateId = h.City.State.StateId,
                    StateName = h.City.State.StateName
                }
            },
            State = h.State == null ? null : new StateDTO
            {
                StateId = h.State.StateId,
                StateName = h.State.StateName
            }
        }).ToListAsync();
        }

        public async Task<HubDTO> GetHubsByAirportCodeAsync(string airportCode)
        {
            var hub = await _fleetDbContext.HubMasters
        .Where(h => h.Airport.AirportCode == airportCode)
        .Select(h => new HubDTO
        {
            HubId = h.HubId,
            ContactNumber = h.ContactNumber,
            HubAddress = h.HubAddress,
            HubName = h.HubName,
            Airport = h.Airport == null ? null : new AirportDTO
            {
                AirportId = h.Airport.AirportId,
                AirportName = h.Airport.AirportName,
                AirportCode = h.Airport.AirportCode,
                City = h.Airport.City == null ? null : new CityDTO
                {
                    CityId = h.Airport.City.CityId,
                    CityName = h.Airport.City.CityName,
                    State = h.Airport.City.State == null ? null : new StateDTO
                    {
                        StateId = h.Airport.City.State.StateId,
                        StateName = h.Airport.City.State.StateName
                    }
                },
                State = h.Airport.State == null ? null : new StateDTO
                {
                    StateId = h.Airport.State.StateId,
                    StateName = h.Airport.State.StateName
                }
            },
            City = h.City == null ? null : new CityDTO
            {
                CityId = h.City.CityId,
                CityName = h.City.CityName,
                State = h.City.State == null ? null : new StateDTO
                {
                    StateId = h.City.State.StateId,
                    StateName = h.City.State.StateName
                }
            },
            State = h.State == null ? null : new StateDTO
            {
                StateId = h.State.StateId,
                StateName = h.State.StateName
            }
        }).FirstOrDefaultAsync();

    if (hub == null)
    {
        throw new KeyNotFoundException($"Hub with airport code '{airportCode}' not found.");
    }

    return hub;
        }

        public async Task<List<HubDTO>> GetHubsByCityIdAsync(long cityID)
        {
            var hubs = await _fleetDbContext.HubMasters
        .Where(h => h.City.CityId == cityID)
        .Select(h => new HubDTO
        {
            HubId = h.HubId,
            ContactNumber = h.ContactNumber,
            HubAddress = h.HubAddress,
            HubName = h.HubName,
            Airport = h.Airport == null ? null : new AirportDTO
            {
                AirportId = h.Airport.AirportId,
                AirportName = h.Airport.AirportName,
                AirportCode = h.Airport.AirportCode,
                City = h.Airport.City == null ? null : new CityDTO
                {
                    CityId = h.Airport.City.CityId,
                    CityName = h.Airport.City.CityName,
                    State = h.Airport.City.State == null ? null : new StateDTO
                    {
                        StateId = h.Airport.City.State.StateId,
                        StateName = h.Airport.City.State.StateName
                    }
                },
                State = h.Airport.State == null ? null : new StateDTO
                {
                    StateId = h.Airport.State.StateId,
                    StateName = h.Airport.State.StateName
                }
            },
            City = h.City == null ? null : new CityDTO
            {
                CityId = h.City.CityId,
                CityName = h.City.CityName,
                State = h.City.State == null ? null : new StateDTO
                {
                    StateId = h.City.State.StateId,
                    StateName = h.City.State.StateName
                }
            },
            State = h.State == null ? null : new StateDTO
            {
                StateId = h.State.StateId,
                StateName = h.State.StateName
            }
        }).ToListAsync();

    if (!hubs.Any())
    {
        throw new KeyNotFoundException($"No hubs found for city ID '{cityID}'.");
    }

    return hubs;
        }

        

        // public async Task<HubMaster> GetHubsByCityNameAsync(string cityName)
        // {
        //     return await _fleetDbContext.HubMasters
        //         .FirstOrDefaultAsync(h => h.City.CityName == cityName)
        //         ?? throw new KeyNotFoundException($"Hub with city name '{cityName}' not found.");
        // }
    }

}
