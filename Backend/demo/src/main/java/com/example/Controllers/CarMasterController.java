package com.example.Controllers;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import com.example.Models.CarMaster;
import com.example.Services.CarMasterService;

@RestController
@RequestMapping("/cars")
@CrossOrigin(origins = "http://localhost:3000")
public class CarMasterController {
    
    @Autowired
    private CarMasterService carMasterService;
    
    @GetMapping("/{id}")
    public ResponseEntity<CarMaster> getCarById(@PathVariable Long id) {
        return carMasterService.getCarById(id)
                .map(ResponseEntity::ok)
                .orElse(ResponseEntity.notFound().build());
    }
    
    @GetMapping
    public List<CarMaster> getAllCars() {
        return carMasterService.getAllCars();
    }
    
    @PutMapping("/{id}")
    public ResponseEntity<CarMaster> updateCar(@PathVariable Long id, @RequestBody CarMaster car) {
        return carMasterService.updateCar(id, car)
                .map(ResponseEntity::ok)
                .orElse(ResponseEntity.notFound().build());
    }
    
    @DeleteMapping("/{id}")
    public ResponseEntity<Void> deleteCar(@PathVariable Long id) {
        if (carMasterService.deleteCar(id)) {
            return ResponseEntity.noContent().build();
        }
        return ResponseEntity.notFound().build();
    }
    
    @GetMapping("/type/{cartypeId}")
    public ResponseEntity<List<CarMaster>> getCarsByCarType(@PathVariable Long cartypeId) {
        List<CarMaster> cars = carMasterService.getCarsByCarType(cartypeId);
        if (cars.isEmpty()) {
            return ResponseEntity.noContent().build();
        }
        return ResponseEntity.ok(cars);
    }
}

