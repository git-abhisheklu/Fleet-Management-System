package com.example.Services;

import com.example.Models.HubMaster;
import com.example.Repositories.HubRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class HubServiceImpl implements HubService {

    @Autowired
    private HubRepository hubRepository;

    @Override
    public List<HubMaster> getAllHubs() {
        return hubRepository.findAll();
    }

    @Override
    public List<HubMaster> getHubsByCityId(Long cityId) {
        return hubRepository.findByCity_CityId(cityId);
    }

    @Override
    public List<HubMaster> getHubsByAirportCode(String airportCode) {
        return hubRepository.findByAirport_AirportCode(airportCode);
    }
}