using Fleet_Management.Models;
using Fleet_Management.Models.DTO;

namespace Fleet_Management.Services
{
    public interface ICarMasterService
    {
        Task<CarMasterDTO> SaveCarAsync(CarMaster car);
        Task<CarMasterDTO?> GetCarByIdAsync(long id);
        Task<List<CarMasterDTO>> GetAllCarsAsync();
        Task<CarMasterDTO?> UpdateCarAsync(long id, CarMaster carDetails);
        //Task<bool> DeleteCarAsync(long id);

    }
}
