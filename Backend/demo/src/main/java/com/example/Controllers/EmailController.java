package com.example.Controllers;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;

import com.example.Models.EmailDetails;
import com.example.Services.EmailService;

@RestController
@CrossOrigin(origins = "http://localhost:3000")
public class EmailController {
 
    @Autowired private EmailService emailService;
 
    @PreAuthorize("permitAll()")
    @PostMapping("/sendMail")
    public ResponseEntity <String> sendMail(@RequestBody EmailDetails details)
    {  	System.out.println(details);    
        String status= emailService.sendSimpleMail(details);
        return ResponseEntity.ok (status);
    }
 
    @PreAuthorize("permitAll()") 
    @PostMapping("/sendMailWithAttachment")
    public String sendMailWithAttachment( @RequestBody EmailDetails details)
    {
        String status= emailService.sendMailWithAttachment(details);
 
        return status;
    }
}