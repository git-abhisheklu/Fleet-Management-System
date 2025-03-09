package com.example.Services;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.example.Models.CityMaster;
import com.example.Repositories.CityRepository;

@Service
public class CityServiceImpl implements CityService {

	@Autowired
	private CityRepository cityRepository;
	
	@Override
	public List<CityMaster> getCitiesByState(Long stateId) {
	    return cityRepository.findByState_StateId(stateId);
	}
}
