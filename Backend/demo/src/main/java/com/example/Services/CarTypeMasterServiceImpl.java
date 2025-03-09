package com.example.Services;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.example.Models.CarTypeMaster;
import com.example.Repositories.CarTypeMasterRepository;


@Service
public class CarTypeMasterServiceImpl implements CarTypeMasterService {

    @Autowired
    private CarTypeMasterRepository carTypeMasterRepository;
//
//    @Override
//    public String updateCarTypeForCustomer(Long customerId, Long newCarTypeId) {
//        int updatedRows = carTypeMasterRepository.updateCarTypeForCustomer(customerId, newCarTypeId);
//        return updatedRows > 0 ? "CarTypeId updated successfully for Customer!" : "No matching CustomerId found!";
//    }


    @Override
    public Optional<CarTypeMaster> getTypeByTypeId(Long carTypeId) {
        return carTypeMasterRepository.findById(carTypeId);
    }


    @Override
    public List<CarTypeMaster> getAllTypes() {
        return carTypeMasterRepository.findAll();
    }
}

