package com.example.Services;

import java.util.List;
import java.util.Optional;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import com.example.Models.CarMaster;
import com.example.Repositories.CarMasterRepository;


@Service
public class CarMasterService {
    
    @Autowired
    private CarMasterRepository carMasterRepository;
    
    public CarMaster saveCar(CarMaster car) {
        return carMasterRepository.save(car);
    }
    
    public Optional<CarMaster> getCarById(Long id) {
        return carMasterRepository.findById(id);
    }
    
    public List<CarMaster> getAllCars() {
        return carMasterRepository.findAll();
    }
    
    public List<CarMaster> getCarsByCarType(Long cartypeId) {
        return carMasterRepository.findByCartypeId_CartypeId(cartypeId);
    }

    public Optional<CarMaster> updateCar(Long id, CarMaster carDetails) {
        return carMasterRepository.findById(id).map(car -> {
            car.setCarTypeId(carDetails.getCarTypeId());
            car.setHub_id(carDetails.getHub_id());
            car.setIsAvailable(carDetails.getIsAvailable());
            car.setMaintenanceduedate(carDetails.getMaintenanceduedate());
            return carMasterRepository.save(car);
        });
    }
    
    public boolean deleteCar(Long id) {
        return carMasterRepository.findById(id).map(car -> {
            carMasterRepository.delete(car);
            return true;
        }).orElse(false);
    }
}


