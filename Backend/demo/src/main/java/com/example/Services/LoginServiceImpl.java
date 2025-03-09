package com.example.Services;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.example.Models.UserLogin;
import com.example.Repositories.LoginRepository;

@Service
public class LoginServiceImpl implements LoginService{

	@Autowired
	private LoginRepository loginRepos;
	
	@Override
	public UserLogin getLogin(String email, String password) {
		// TODO Auto-generated method stub
		return loginRepos.getLogin(email, password);
	}
//
//	@Override
//	public void updatePassword(String email,String password, String newPassword) {
//		// TODO Auto-generated method stub
//		UserDetails user=loginRepos.findByEmail(email);
//		if(user!=null && user.getPassword().equals(password)) {
//			user.setPassword(newPassword);
//			loginRepos.save(user);
//		}
//	}
//
//	@Override
//	public void forgotPassword(String email, String newPassword) {
//		// TODO Auto-generated method stub
//		UserDetails user=loginRepos.findByEmail(email);
//		if(user!=null) {
//			user.setPassword(newPassword);
//			loginRepos.save(user);
//		}
//	}

}
