package com.example.Controllers;

import com.example.Models.CityMaster;
import com.example.Services.CityService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
@RequestMapping("/api/cities")
@CrossOrigin(origins = "http://localhost:3000")
public class CityController {

    @Autowired
    private CityService cityService;

    @GetMapping("/state/{stateId}")
    public List<CityMaster> getCitiesByState(@PathVariable Long stateId) {
        return cityService.getCitiesByState(stateId);
    }
}


