using Fleet_Management.Models;
using Fleet_Management.Repository;
using Microsoft.EntityFrameworkCore;

namespace Fleet_Management.Service
{
    public class CityServiceImpl : ICityService
    {
        private readonly FleetDbContext _fleetDbContext;

        public CityServiceImpl(FleetDbContext fleetDbContext)
        {
            _fleetDbContext = fleetDbContext;
        }
        public async Task<List<CityDTO>> GetCitiesByStateAsync(long stateId)
        {
            return await _fleetDbContext.CityMasters
                .Where(c => c.State.StateId == stateId)
                .Include(c => c.State)
                .Select(c => new CityDTO
                {
                    CityId = c.CityId,
                    CityName = c.CityName,
                    State = new StateDTO
                    {
                        StateId = c.State.StateId,
                        StateName = c.State.StateName
                    }
                }).ToListAsync();
        }

        // public async Task<List<CityMaster>> GetCitiesByStateNameAsync(string stateName)
        // {
        //     return await _fleetDbContext.CityMasters
        //         .Where(c => EF.Functions.Like(c.State.StateName, $"%stateName"))
        //         .ToListAsync();
        // }
    }

}
