	package com.example.Services;
	
	import java.util.List;
	import java.util.Optional;
	
	import com.example.Models.AirportMaster;
	
	public interface AirportMasterService {
	    List<AirportMaster> getAllAirports();
	    Optional<AirportMaster> getAirportById(long id);
		Optional<AirportMaster> getAirportByCode(String airportCode);
	}
