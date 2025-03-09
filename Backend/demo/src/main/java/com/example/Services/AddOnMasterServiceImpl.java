package com.example.Services;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.example.Models.AddOnMaster;
import com.example.Repositories.AddOnMasterRepository;

@Service
public class AddOnMasterServiceImpl implements AddOnMasterService {

    @Autowired
    private AddOnMasterRepository addOnMasterRepository; // Autowiring the repository to interact with the database

    @Override
    public AddOnMaster getAddOnById(Long addonId) {
        // Fetch AddOnMaster from the database by its addonId
        return addOnMasterRepository.findById(addonId).orElse(null); // Returns null if not found
    }

    @Override
    public AddOnMaster deleteAddOnById(Long addonId) {
        // Find AddOnMaster by ID
        AddOnMaster addOnMaster = addOnMasterRepository.findById(addonId).orElse(null);

        if (addOnMaster != null) {
            // Delete AddOnMaster if it exists
            addOnMasterRepository.deleteById(addonId);
        }

        return addOnMaster; // Return the deleted AddOnMaster object (or null if not found)
    }

    @Override
    public AddOnMaster updateAddOn(Long addonId, AddOnMaster updatedAddOn) {
        // Check if the AddOnMaster exists
        Optional<AddOnMaster> existingAddOnMasterOpt = addOnMasterRepository.findById(addonId);

        // If AddOnMaster exists, update it
        if (existingAddOnMasterOpt.isPresent()) {
            AddOnMaster existingAddOnMaster = existingAddOnMasterOpt.get();
            // Set the updated fields from updatedAddOn to existingAddOnMaster
            existingAddOnMaster.setAddonName(updatedAddOn.getAddonName());
            existingAddOnMaster.setAddonDailyRate(updatedAddOn.getAddonDailyRate());
            existingAddOnMaster.setRateValidUpto(updatedAddOn.getRateValidUpto());

            // Save and return the updated AddOnMaster
            return addOnMasterRepository.save(existingAddOnMaster);
        }

        // Return null if AddOnMaster with given addonId doesn't exist
        return null;
    }

    @Override
    public List<AddOnMaster> getAllAddOns() {
        // Fetch all AddOnMaster records from the database
        return addOnMasterRepository.findAll();
    }

    @Override
    public AddOnMaster createAddOn(AddOnMaster addOnMaster) {
        // Save and return the new AddOnMaster
        return addOnMasterRepository.save(addOnMaster); // Persist the AddOnMaster and return it
    }
}
