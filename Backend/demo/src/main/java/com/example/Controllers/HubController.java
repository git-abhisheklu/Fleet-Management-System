package com.example.Controllers;

import com.example.Models.HubMaster;
import com.example.Services.HubService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/hubs")
@CrossOrigin(origins = "http://localhost:3000")
public class HubController {

    @Autowired
    private HubService hubService;

    @GetMapping
    public List<HubMaster> getAllHubs() {
        return hubService.getAllHubs();
    }

    @GetMapping("/city/{cityId}")
    public List<HubMaster> getHubsByCityId(@PathVariable Long cityId) {
        return hubService.getHubsByCityId(cityId);
    }

    @GetMapping("/airportCode/{airportCode}")
    public List<HubMaster> getHubsByAirportCode(@PathVariable String airportCode) {
        return hubService.getHubsByAirportCode(airportCode);
    }
}