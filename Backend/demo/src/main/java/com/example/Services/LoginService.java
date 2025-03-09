package com.example.Services;

import com.example.Models.UserLogin;

public interface LoginService {
	UserLogin getLogin(String email,String password);	
	
//	void updatePassword(String email,String password,String newPassword);
//	
//	void forgotPassword(String email,String newPassword);
}
