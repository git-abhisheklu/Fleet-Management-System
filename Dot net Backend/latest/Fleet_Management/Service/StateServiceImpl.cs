using Fleet_Management.Models;
using Fleet_Management.Repository;
using Microsoft.EntityFrameworkCore;

namespace Fleet_Management.Service
{
    public class StateServiceImpl : IStateService
    {
        private readonly FleetDbContext _fleetDbContext;

        public StateServiceImpl(FleetDbContext fleetDbContext)
        {
            _fleetDbContext = fleetDbContext;
        }
        public async Task<List<StateMaster>> GetAllStateAsync()
        {
            return await _fleetDbContext.StateMasters.ToListAsync();
        }
    }

}
