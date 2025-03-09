using Fleet_Management.Models;
using Fleet_Management.Models.DTO;

namespace Fleet_Management.Service
{
    public interface IAddOnMasterService
    {
        Task<AddOnMasterDTO?> GetAddOnByIdAsync(long addOnMasterId);
        Task<AddOnMaster?> DeleteAddOnByIdAsync(long addonId);
        Task<AddOnMaster?> UpdateAddOnByIdAsync(AddOnMaster addOnMaster);
        Task<AddOnMaster?> CreateAddOnAsync(AddOnMaster addOnMaster);
        Task<List<AddOnMasterDTO>> GetAllAddOnsAsync();
    }
}