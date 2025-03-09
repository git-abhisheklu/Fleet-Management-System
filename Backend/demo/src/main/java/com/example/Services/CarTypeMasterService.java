package com.example.Services;


import com.example.Models.CarTypeMaster;
import java.util.List;
import java.util.Optional;


public interface CarTypeMasterService {


//    String updateCarTypeForCustomer(Long customerId, Long newCarTypeId);


    Optional<CarTypeMaster> getTypeByTypeId(Long carTypeId);


    List<CarTypeMaster> getAllTypes();
}