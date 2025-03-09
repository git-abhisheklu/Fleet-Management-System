using Fleet_Management.Models;
using Fleet_Management.Models.DTO;
using Fleet_Management.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Fleet_Management.Services
{
    public class CarMasterServiceImpl : ICarMasterService
    {
        private readonly FleetDbContext _context;

        public CarMasterServiceImpl(FleetDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<CarMasterDTO?> SaveCarAsync(CarMaster car)
        {
            _context.CarMasters.Add(car);
            await _context.SaveChangesAsync();

            return await GetCarByIdAsync(car.CarId);
        }

        public async Task<CarMasterDTO?> GetCarByIdAsync(long id)
        {
            var car = await _context.CarMasters
        .Include(c => c.Hub)
            .ThenInclude(h => h.Airport)
                .ThenInclude(a => a.City)
                    .ThenInclude(city => city.State)
        .Include(c => c.Hub)
            .ThenInclude(h => h.City)
                .ThenInclude(city => city.State)
        .Include(c => c.Hub)
            .ThenInclude(h => h.State)
        .Include(c => c.Cartype)
        .FirstOrDefaultAsync(c => c.CarId == id);

            if (car == null) return null;

            return new CarMasterDTO
            {
                CarId = car.CarId,
                CarName = car.CarName,
                NumberPlate = car.NumberPlate,
                FuelStatus = car.FuelStatus,
                IsAvailable = car.IsAvailable,
                MaintenanceDueDate = car.Maintenanceduedate,
                Hub = new HubDTO
                {
                    HubId = car.Hub.HubId,
                    ContactNumber = car.Hub.ContactNumber,
                    HubAddress = car.Hub.HubAddress,
                    HubName = car.Hub.HubName,
                    Airport = new AirportDTO
                    {
                        AirportId = car.Hub.Airport.AirportId,
                        AirportName = car.Hub.Airport.AirportName,
                        AirportCode = car.Hub.Airport.AirportCode,
                        City = new CityDTO
                        {
                            CityId = car.Hub.Airport.City.CityId,
                            CityName = car.Hub.Airport.City.CityName,
                            State = new StateDTO
                            {
                                StateId = car.Hub.Airport.City.State.StateId,
                                StateName = car.Hub.Airport.City.State.StateName
                            }
                        },
                        State = new StateDTO
                        {
                            StateId = car.Hub.Airport.State.StateId,
                            StateName = car.Hub.Airport.State.StateName
                        }
                    },
                    City = new CityDTO
                    {
                        CityId = car.Hub.City.CityId,
                        CityName = car.Hub.City.CityName,
                        State = new StateDTO
                        {
                            StateId = car.Hub.City.State.StateId,
                            StateName = car.Hub.City.State.StateName
                        }
                    },
                    State = new StateDTO
                    {
                        StateId = car.Hub.State.StateId,
                        StateName = car.Hub.State.StateName
                    }
                },
                CarType = new CarTypeMasterDTO
                {
                    CartypeId = car.Cartype.CartypeId,
                    CarTypeName = car.Cartype.CarTypeName,
                    DailyRate = car.Cartype.DailyRate,
                    WeeklyRate = car.Cartype.WeeklyRate,
                    MonthlyRate = car.Cartype.MonthlyRate,
                    ImagePath = car.Cartype.ImagePath
                }
            };
        }

        public async Task<List<CarMasterDTO>> GetAllCarsAsync()
        {
            var cars = await _context.CarMasters
        .Include(c => c.Hub)
            .ThenInclude(h => h.Airport)
                .ThenInclude(a => a.City)
                    .ThenInclude(city => city.State)
        .Include(c => c.Hub)
            .ThenInclude(h => h.City)
                .ThenInclude(city => city.State)
        .Include(c => c.Hub)
            .ThenInclude(h => h.State)
        .Include(c => c.Cartype)
        .ToListAsync();

            return cars.Select(car => new CarMasterDTO
            {
                CarId = car.CarId,
                CarName = car.CarName,
                NumberPlate = car.NumberPlate,
                FuelStatus = car.FuelStatus,
                IsAvailable = car.IsAvailable,
                MaintenanceDueDate = car.Maintenanceduedate,
                Hub = new HubDTO
                {
                    HubId = car.Hub.HubId,
                    ContactNumber = car.Hub.ContactNumber,
                    HubAddress = car.Hub.HubAddress,
                    HubName = car.Hub.HubName,
                    Airport = new AirportDTO
                    {
                        AirportId = car.Hub.Airport.AirportId,
                        AirportName = car.Hub.Airport.AirportName,
                        AirportCode = car.Hub.Airport.AirportCode,
                        City = new CityDTO
                        {
                            CityId = car.Hub.Airport.City.CityId,
                            CityName = car.Hub.Airport.City.CityName,
                            State = new StateDTO
                            {
                                StateId = car.Hub.Airport.City.State.StateId,
                                StateName = car.Hub.Airport.City.State.StateName
                            }
                        },
                        State = new StateDTO
                        {
                            StateId = car.Hub.Airport.State.StateId,
                            StateName = car.Hub.Airport.State.StateName
                        }
                    },
                    City = new CityDTO
                    {
                        CityId = car.Hub.City.CityId,
                        CityName = car.Hub.City.CityName,
                        State = new StateDTO
                        {
                            StateId = car.Hub.City.State.StateId,
                            StateName = car.Hub.City.State.StateName
                        }
                    },
                    State = new StateDTO
                    {
                        StateId = car.Hub.State.StateId,
                        StateName = car.Hub.State.StateName
                    }
                },
                CarType = new CarTypeMasterDTO
                {
                    CartypeId = car.Cartype.CartypeId,
                    CarTypeName = car.Cartype.CarTypeName,
                    DailyRate = car.Cartype.DailyRate,
                    WeeklyRate = car.Cartype.WeeklyRate,
                    MonthlyRate = car.Cartype.MonthlyRate,
                    ImagePath = car.Cartype.ImagePath
                }
            }).ToList();
        }

        public async Task<CarMasterDTO?> UpdateCarAsync(long id,[FromBody] CarMaster carDetails)
        {
            var car = await _context.CarMasters
        .Include(c => c.Hub)
            .ThenInclude(h => h.Airport)
                .ThenInclude(a => a.City)
                    .ThenInclude(city => city.State)
        .Include(c => c.Hub)
            .ThenInclude(h => h.City)
                .ThenInclude(city => city.State)
        .Include(c => c.Hub)
            .ThenInclude(h => h.State)
        .Include(c => c.Cartype)
        .FirstOrDefaultAsync(c => c.CarId == id);

            if (car == null) return null;

            car.CartypeId = carDetails.CartypeId;
            car.HubId = carDetails.HubId;
            car.IsAvailable = carDetails.IsAvailable;
            car.Maintenanceduedate = carDetails.Maintenanceduedate;

            _context.CarMasters.Update(car);
            await _context.SaveChangesAsync();

            return new CarMasterDTO
            {
                CarId = car.CarId,
                CarName = car.CarName,
                NumberPlate = car.NumberPlate,
                FuelStatus = car.FuelStatus,
                IsAvailable = car.IsAvailable,
                MaintenanceDueDate = car.Maintenanceduedate,
                Hub = new HubDTO
                {
                    HubId = car.Hub.HubId,
                    ContactNumber = car.Hub.ContactNumber,
                    HubAddress = car.Hub.HubAddress,
                    HubName = car.Hub.HubName,
                    Airport = new AirportDTO
                    {
                        AirportId = car.Hub.Airport.AirportId,
                        AirportName = car.Hub.Airport.AirportName,
                        AirportCode = car.Hub.Airport.AirportCode,
                        City = new CityDTO
                        {
                            CityId = car.Hub.Airport.City.CityId,
                            CityName = car.Hub.Airport.City.CityName,
                            State = new StateDTO
                            {
                                StateId = car.Hub.Airport.City.State.StateId,
                                StateName = car.Hub.Airport.City.State.StateName
                            }
                        },
                        State = new StateDTO
                        {
                            StateId = car.Hub.Airport.State.StateId,
                            StateName = car.Hub.Airport.State.StateName
                        }
                    },
                    City = new CityDTO
                    {
                        CityId = car.Hub.City.CityId,
                        CityName = car.Hub.City.CityName,
                        State = new StateDTO
                        {
                            StateId = car.Hub.City.State.StateId,
                            StateName = car.Hub.City.State.StateName
                        }
                    },
                    State = new StateDTO
                    {
                        StateId = car.Hub.State.StateId,
                        StateName = car.Hub.State.StateName
                    }
                },
                CarType = new CarTypeMasterDTO
                {
                    CartypeId = car.Cartype.CartypeId,
                    CarTypeName = car.Cartype.CarTypeName,
                    DailyRate = car.Cartype.DailyRate,
                    WeeklyRate = car.Cartype.WeeklyRate,
                    MonthlyRate = car.Cartype.MonthlyRate,
                    ImagePath = car.Cartype.ImagePath
                }
            };
        }


        // public async Task<bool> DeleteCarAsync(long id)
        // {
        //     var car = await _context.CarMasters.FindAsync(id);
        //     if (car == null) return false;

        //     _context.CarMasters.Remove(car);
        //     await _context.SaveChangesAsync();
        //     return true;
        // }
    }

}
