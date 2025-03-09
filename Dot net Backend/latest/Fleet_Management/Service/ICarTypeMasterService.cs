using Fleet_Management.Models.DTO;

namespace Fleet_Management.Service
{
    public interface ICarTypeMasterService
    {
        Task<CarTypeMasterDTO?> GetTypeByTypeIdAsync(long carTypeId);
        Task<List<CarTypeMasterDTO>> GetAllTypesAsync();
    }
}