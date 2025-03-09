package com.example.Controllers;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import com.example.Models.UserLogin;
import com.example.Services.LoginService;

@RestController
@RequestMapping("/login")
@CrossOrigin(origins = "http://localhost:3000")
public class LoginController {

    @Autowired
    private LoginService loginService;

    @GetMapping
    public UserLogin login(@RequestParam String email, @RequestParam String password) {
        return loginService.getLogin(email, password);
    }
    
//    @PutMapping("/update-password")
//    public String updatePassword(@RequestParam String email,@RequestParam String password,@RequestParam String newPassword) {
//    	loginService.updatePassword(email, password, newPassword);
//    	return "password updated";
//    }
//    
//    @PostMapping("/forgot-password")
//    public String forgotPassword(@RequestParam String Email,@RequestParam String newPassword) {
//    	loginService.forgotPassword(Email, newPassword);
//    	return "password reset successfully";
//    }
}