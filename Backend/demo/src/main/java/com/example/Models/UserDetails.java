package com.example.Models;

import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;

@Entity
public class UserDetails {
	
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private Long userid;
	
	private String userName;
	
	private String lastName;
	
	private String email;
	
	private String password;

	public long getUserid() {
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

	@Override
	public String toString() {
		return "UserDetails [userid=" + userid + ", userName=" + userName + ", lastName=" + lastName + ", email="
				+ email + ", password=" + password + ", confirmPassword=" + "]";
	}

	public UserDetails(Long userid, String userName, String lastName, String email, String password,
			String confirmPassword) {
		super();
		this.userid = userid;
		this.userName = userName;
		this.lastName = lastName;
		this.email = email;
		this.password = password;
	}
	
	public UserDetails() {
		// TODO Auto-generated constructor stub
	}
}
