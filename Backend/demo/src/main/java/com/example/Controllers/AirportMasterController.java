package com.example.Controllers;

import java.util.List;
import java.util.Optional;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import com.example.Models.AirportMaster;
import com.example.Services.AirportMasterService;

@RestController
@RequestMapping("/api/airports")
@CrossOrigin(origins = "http://localhost:3000")
public class AirportMasterController {

    
    @Autowired
    private AirportMasterService airportmasterservice;

    @GetMapping
    public List<AirportMaster> getAllAirports() {
        return airportmasterservice.getAllAirports();
    }

    @GetMapping("/{id}")
    public ResponseEntity<AirportMaster> getAirportById(@PathVariable long id) {
        Optional<AirportMaster> airport = airportmasterservice.getAirportById(id);
        return airport.map(ResponseEntity::ok).orElseGet(() -> ResponseEntity.notFound().build());
    }
    
    @GetMapping("/code/{airportCode}")
    public ResponseEntity<AirportMaster> getAirportByCode(@PathVariable String airportCode) {
        Optional<AirportMaster> airport = airportmasterservice.getAirportByCode(airportCode);
        return airport.map(ResponseEntity::ok).orElseGet(() -> ResponseEntity.notFound().build());
    }
}
