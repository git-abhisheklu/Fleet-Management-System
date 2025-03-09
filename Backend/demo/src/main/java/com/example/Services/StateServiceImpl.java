package com.example.Services;

import com.example.Models.StateMaster;
import com.example.Repositories.StateRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class StateServiceImpl implements StateService {

    @Autowired
    private StateRepository stateRepository;

    @Override
    public List<StateMaster> getAllStates() {
        return stateRepository.findAll();
    }
}

