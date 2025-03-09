package com.example.Services;

import java.util.List;

import com.example.Models.CityMaster;

public interface CityService {
	public List<CityMaster> getCitiesByState(Long StateId);
}
