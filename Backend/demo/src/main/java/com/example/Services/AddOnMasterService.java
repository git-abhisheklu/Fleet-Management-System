package com.example.Services;

import java.util.List;
import com.example.Models.AddOnMaster;

public interface AddOnMasterService {
    
    // Method to get all AddOns
    List<AddOnMaster> getAllAddOns();
    
    // Method to get an AddOn by its addonId
    AddOnMaster getAddOnById(Long addonId);

    // Method to delete an AddOn by its addonId
    AddOnMaster deleteAddOnById(Long addonId);

    // Method to update an existing AddOn by its addonId
    AddOnMaster updateAddOn(Long addonId, AddOnMaster updatedAddOn);

	AddOnMaster createAddOn(AddOnMaster addOnMaster);
}
