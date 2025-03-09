package com.example.Services;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.example.Models.AirportMaster;
import com.example.Repositories.AirportMasterRepository;

@Service  
public class AirportMasterImpl implements AirportMasterService {

    @Autowired
    private AirportMasterRepository airportMasterRepository;

    @Override
    public List<AirportMaster> getAllAirports() {
        return airportMasterRepository.findAll();
    }

    @Override
    public Optional<AirportMaster> getAirportById(long id) {
        return airportMasterRepository.findById(id);
    }

	@Override
	public Optional<AirportMaster> getAirportByCode(String airportCode) {
        return airportMasterRepository.findByAirportCode(airportCode);
	}
}
