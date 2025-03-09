package com.example.Repositories;

import com.example.Models.HubMaster;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import java.util.List;

@Repository
public interface HubRepository extends JpaRepository<HubMaster, Long> {

    List<HubMaster> findByCity_CityId(Long cityId);

    List<HubMaster> findByAirport_AirportCode(String airportCode);
}
