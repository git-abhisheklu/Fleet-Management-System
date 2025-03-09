package com.example.Controllers;

import com.example.Models.StateMaster;
import com.example.Services.StateService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
@RequestMapping("/api/states")
@CrossOrigin(origins = "http://localhost:3000")
public class StateController {

    @Autowired
    private StateService stateService;  // This is the interface

    @GetMapping
    public List<StateMaster> getAllStates() {
        return stateService.getAllStates();
    }
}


