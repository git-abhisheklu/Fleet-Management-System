package com.example.Repositories;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.example.Models.UserLogin;



@Repository
public interface UserRepository extends JpaRepository<UserLogin, Long>{
	
	UserLogin findByEmail(String email);
}
