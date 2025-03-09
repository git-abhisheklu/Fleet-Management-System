package com.example.Repositories;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import com.example.Models.CarTypeMaster;

import jakarta.transaction.Transactional;


@Repository
public interface CarTypeMasterRepository extends JpaRepository<CarTypeMaster, Long> {

//    @Modifying
//    @Transactional
//    @Query("UPDATE bookingDetail b SET b.cartypeId = :newCarTypeId WHERE b.cartype_id = :customerId")
//    int updateCarTypeForCustomer(Long customerId, Long newCarTypeId);
}
