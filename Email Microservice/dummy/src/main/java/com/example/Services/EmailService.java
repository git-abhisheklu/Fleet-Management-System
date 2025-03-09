package com.example.Services;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.example.Mail.EmailSender;

@Service
public class EmailService {

	@Autowired
	private EmailSender sender;
    public void sendEmail(String to, String subject, String message) {
    	
       
        System.out.println("Sending email to: " + to);
        System.out.println("Subject: " + subject);
        System.out.println("Message: " + message);
        sender.send(subject, message);
    }
}
