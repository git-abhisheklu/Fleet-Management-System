

using Fleet_Management.Models;
using Fleet_Management.Models.DTO;
using Fleet_Management.Repository;
using Microsoft.EntityFrameworkCore;

namespace Fleet_Management.Service
{
    public class AddOnMasterService : IAddOnMasterService
    {
        private readonly FleetDbContext _fleetDbContext;

        public AddOnMasterService(FleetDbContext _fleetDbContext)
        {
            this._fleetDbContext = _fleetDbContext;
        }

        public async Task<AddOnMasterDTO?> GetAddOnByIdAsync(long addOnMasterId)
        {
            var addOnMaster = await _fleetDbContext.AddOnMasters
                           .AsNoTracking()  // Prevents loading related entities
                           .Where(b => b.AddonId == addOnMasterId)
                           .Select(b => new AddOnMasterDTO
                           {
                               AddonId = b.AddonId,
                               AddonName = b.AddonName,
                               AddonDailyRate = b.AddonDailyRate,
                               RateValidUpto = b.RateValidUpto
                           })
                           .FirstOrDefaultAsync();

    return addOnMaster;
        } 

        public async Task<AddOnMaster?> DeleteAddOnByIdAsync(long addonId)
        {
           var add_on_master = await _fleetDbContext.AddOnMasters.FirstOrDefaultAsync(b => b.AddonId == addonId);
           if (add_on_master != null)
           {
               _fleetDbContext.AddOnMasters.Remove(add_on_master);
               await _fleetDbContext.SaveChangesAsync();
               return add_on_master;
           }
           return add_on_master;
        }

        public async Task<AddOnMaster?> UpdateAddOnByIdAsync(AddOnMaster addOnMaster)
        {
            var add_on_master = await _fleetDbContext.AddOnMasters.FirstOrDefaultAsync(b => b.AddonId == addOnMaster.AddonId);
            if (add_on_master != null)
            {
                add_on_master.AddonName = addOnMaster.AddonName;
                add_on_master.AddonDailyRate = addOnMaster.AddonDailyRate;
                add_on_master.RateValidUpto = addOnMaster.RateValidUpto;
                await _fleetDbContext.SaveChangesAsync();
                return add_on_master;
            }
            return add_on_master;
        }

        public async Task<AddOnMaster?> CreateAddOnAsync(AddOnMaster addOnMaster)
        {
            await _fleetDbContext.AddOnMasters.AddAsync(addOnMaster);
            await _fleetDbContext.SaveChangesAsync();
            return addOnMaster;
        }

        public async Task<List<AddOnMasterDTO>> GetAllAddOnsAsync()
        {
            var addOnMasters = await _fleetDbContext.AddOnMasters
                            .AsNoTracking()  // Prevents loading related entities
                            .Select(addOn => new AddOnMasterDTO
                            {
                                AddonId = addOn.AddonId,
                                AddonName = addOn.AddonName,
                                AddonDailyRate = addOn.AddonDailyRate,
                                RateValidUpto = addOn.RateValidUpto 
                            })
                            .ToListAsync();

    return addOnMasters;
        }
    }
}   