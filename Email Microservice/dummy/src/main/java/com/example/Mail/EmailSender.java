package com.example.Mail;

import java.util.Properties;
import org.springframework.stereotype.Component;
import jakarta.mail.*;
import jakarta.mail.internet.*;

@Component
public class EmailSender {

    public void send(String subject, String message) {
        final String username = "adityachoudhary8965@gmail.com";
        final String password = "zuvy fdwo inbf msyu";

        Properties props = new Properties();
        props.put("mail.smtp.auth", "true");
        props.put("mail.smtp.starttls.enable", "true");
        props.put("mail.smtp.host", "smtp.gmail.com");
        props.put("mail.smtp.port", "587");

        Session session = Session.getInstance(props,
                new jakarta.mail.Authenticator() {
                    protected PasswordAuthentication getPasswordAuthentication() {
                        return new PasswordAuthentication(username, password);
                    }
                });

        try {
            MimeMessage message1 = new MimeMessage(session);
            message1.setRecipients(Message.RecipientType.TO,
                    InternetAddress.parse("adityachoudhary252002@gmail.com"));
            message1.setSubject(subject);

            // HTML email content
            String htmlMessage = "<html><body style='font-family: Arial, sans-serif; color: #333;'>"
                    + "<div style='border: 1px solid #ddd; padding: 20px; max-width: 600px; margin: auto; border-radius: 10px;'>"
                    + "<h2 style='color: #007bff; text-align: center;'>Hire&Go Notification</h2>"
                    + "<p>Dear User,</p>"
                    + "<p>" + message + "</p>"
                    + "<p>For more details, please visit your dashboard.</p>"
                    + "<br>"
                    + "<p style='font-size: 14px; text-align: center; color: #555;'>Best Regards,</p>"
                    + "<p style='font-size: 14px; text-align: center; font-weight: bold;'>Hire&Go Team</p>"
                    + "</div></body></html>";


            MimeBodyPart part2 = new MimeBodyPart();
            part2.setContent(htmlMessage, "text/html"); // Setting HTML content

            Multipart multipart = new MimeMultipart();
            multipart.addBodyPart(part2);

            message1.setContent(multipart);
            Transport.send(message1);

            System.out.println("Email Sent Successfully");

        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
