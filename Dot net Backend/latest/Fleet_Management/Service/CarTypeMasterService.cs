using Fleet_Management.Models;
using Fleet_Management.Models.DTO;
using Fleet_Management.Repository;
using Microsoft.EntityFrameworkCore;

namespace Fleet_Management.Service
{
    public class CarTypeMasterService : ICarTypeMasterService
    {
        private readonly FleetDbContext _context;

        public CarTypeMasterService(FleetDbContext context)
        {
            _context = context;
        }

        public async Task<CarTypeMasterDTO?> GetTypeByTypeIdAsync(long carTypeId)
        {
            var carType = await _context.CarTypeMasters
                                        .FirstOrDefaultAsync(ct => ct.CartypeId == carTypeId);

            if (carType == null)
                return null;

            return new CarTypeMasterDTO
            {
                CartypeId = carType.CartypeId,
                CarTypeName = carType.CarTypeName,
                DailyRate = carType.DailyRate,
                WeeklyRate = carType.WeeklyRate,
                MonthlyRate = carType.MonthlyRate,
                ImagePath = carType.ImagePath
            };
        }

        public async Task<List<CarTypeMasterDTO>> GetAllTypesAsync()
        {
            return await _context.CarTypeMasters
                                 .Select(carType => new CarTypeMasterDTO
                                 {
                                     CartypeId = carType.CartypeId,
                                     CarTypeName = carType.CarTypeName,
                                     DailyRate = carType.DailyRate,
                                     WeeklyRate = carType.WeeklyRate,
                                     MonthlyRate = carType.MonthlyRate,
                                     ImagePath = carType.ImagePath
                                 })
                                 .ToListAsync();
        }
    }
}
