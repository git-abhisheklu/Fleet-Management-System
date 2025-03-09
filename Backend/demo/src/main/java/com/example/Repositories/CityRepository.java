package com.example.Repositories;

import com.example.Models.CityMaster;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;

public interface CityRepository extends JpaRepository<CityMaster, Long> {
    List<CityMaster> findByState_StateId(Long stateId);
}

