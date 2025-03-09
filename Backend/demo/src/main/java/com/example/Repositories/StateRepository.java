package com.example.Repositories;

import com.example.Models.StateMaster;


import org.springframework.data.jpa.repository.JpaRepository;

public interface StateRepository extends JpaRepository<StateMaster, Long> {
}

