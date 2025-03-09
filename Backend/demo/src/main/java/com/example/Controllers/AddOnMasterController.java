package com.example.Controllers;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import com.example.Models.AddOnMaster;
import com.example.Services.AddOnMasterService;

@RestController
@RequestMapping("/api/addons")
@CrossOrigin(origins = "http://localhost:3000")
public class AddOnMasterController {

    @Autowired
    private AddOnMasterService addOnMasterService; 


    @GetMapping
    public ResponseEntity<List<AddOnMaster>> getAllAddOns() {
        List<AddOnMaster> addOns = addOnMasterService.getAllAddOns();
        if (addOns.isEmpty()) {
            return new ResponseEntity<>(HttpStatus.NO_CONTENT); 
        }
        return new ResponseEntity<>(addOns, HttpStatus.OK); 
    }

    
    @GetMapping("/{addonId}")
    public ResponseEntity<AddOnMaster> getAddOnById(@PathVariable Long addonId) {
        AddOnMaster addOnMaster = addOnMasterService.getAddOnById(addonId);
        if (addOnMaster == null) {
            return new ResponseEntity<>(HttpStatus.NOT_FOUND);
        }
        return new ResponseEntity<>(addOnMaster, HttpStatus.OK); 
    }

    
    @DeleteMapping("/{addonId}")
    public ResponseEntity<String> deleteAddOnById(@PathVariable Long addonId) {
        AddOnMaster addOnMaster = addOnMasterService.deleteAddOnById(addonId);
        if (addOnMaster == null) {
            return new ResponseEntity<>("AddOn not found", HttpStatus.NOT_FOUND); 
        }
        return new ResponseEntity<>("AddOn deleted successfully", HttpStatus.OK); 
    }

    @PutMapping("/{addonId}")
    public ResponseEntity<AddOnMaster> updateAddOn(
            @PathVariable Long addonId,
            @RequestBody AddOnMaster updatedAddOn) {
        AddOnMaster updated = addOnMasterService.updateAddOn(addonId, updatedAddOn);
        if (updated == null) {
            return new ResponseEntity<>(HttpStatus.NOT_FOUND);
        }
        return new ResponseEntity<>(updated, HttpStatus.OK); 
    }

    @PostMapping
    public ResponseEntity<AddOnMaster> createAddOn(@RequestBody AddOnMaster addOnMaster) {
        AddOnMaster createdAddOn = addOnMasterService.createAddOn(addOnMaster); 
        return new ResponseEntity<>(createdAddOn, HttpStatus.CREATED);     }
}
