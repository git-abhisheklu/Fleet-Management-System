package com.example.Models;

import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;

@Entity
public class UserLogin {
    
    
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long userid;
    
    private String userName;
    
    private String firstName;
    
    public String getFirstName() {
        return firstName;
    }

    public void setFirstName(String firstName) {
        this.firstName = firstName;
    }

    private String lastName;
    
    private String email;
    
    private String password;
    
    private String role;

    public Long getUserid() {
        return userid;
    }

    public void setUserid(Long userid) {
      
        this.userid = userid;
    }

    public String getUserName() {
    
        return userName;
    }

    public void setUserName(String userName) {
     
        this.userName = userName;
    }

    public String getLastName() {
        return lastName;
    }

    public void setLastName(String lastName) {
      
        this.lastName = lastName;
    }

    public String getEmail() {
     
        return email;
    }

    public void setEmail(String email) {
      
        this.email = email;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
      
        this.password = password;
    }

    public String getRole() {
        return role;
    }

    public void setRole(String role) {
       
        this.role = role;
    }

    public UserLogin() {
    }

    public UserLogin(Long userid, String userName, String firstName, String lastName, String email, String password, String role) {
        super();
        this.userid = userid;
        this.userName = userName;
        this.firstName = firstName;
        this.lastName = lastName;
        this.email = email;
        this.password = password;
        this.role = role;
        
    }

    @Override
    public String toString() {
        return "UserDetails [userid=" + userid + ", userName=" + userName + ", firstName=" + firstName + ", lastName="
                + lastName + ", email=" + email + ", password=" + password + ", role=" + role + "]";
    }
}
