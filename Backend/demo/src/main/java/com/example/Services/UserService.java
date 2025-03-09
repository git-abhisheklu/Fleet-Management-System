package com.example.Services;

import java.util.List;
import java.util.Optional;

import com.example.Models.UserLogin;


public interface UserService {
	 void addUser(UserLogin user);
	 List<UserLogin> getAllUser();
	 UserLogin getUserByEmailId(String email);
	 Optional<UserLogin> getUserByid(int email);
	 void removeByEmail(String email);
	 void updateUserByEmail(String email,UserLogin user);
}
