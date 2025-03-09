package com.example.Services;

import com.example.Models.HubMaster;
import java.util.List;

public interface HubService {

    List<HubMaster> getAllHubs();

    List<HubMaster> getHubsByCityId(Long cityId);

    List<HubMaster> getHubsByAirportCode(String airportCode);
}