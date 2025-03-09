package com.example.Controllers;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;
import com.example.Services.EmailService;
import java.util.Map;

@RestController
@CrossOrigin(origins = "http://localhost:3000")
public class EmailController {

    @Autowired
    private EmailService service;

    @PostMapping("/email")
    public void sendEmail(@RequestBody Map<String, String> emailRequest) {
        String recipientEmail = emailRequest.get("email");
        String message = emailRequest.get("message");

        // Set subject automatically inside the service
        String subject = "Booking Confirmation";

        service.sendEmail(recipientEmail, subject, message);
    }
}
