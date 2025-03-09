package com.example.Repositories;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;
import com.example.Models.CarMaster;

@Repository
public interface CarMasterRepository extends JpaRepository<CarMaster, Long> {
	 List<CarMaster> findByCartypeId_CartypeId(Long cartypeId);
}

