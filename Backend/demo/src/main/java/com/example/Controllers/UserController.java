package com.example.Controllers;

import java.util.List;
import java.util.Optional;

import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import com.example.Models.UserLogin;
import com.example.Services.UserService;

@RestController
@RequestMapping("/register")
@CrossOrigin(origins = "http://localhost:3000")
public class UserController {

    private static final Logger logger = LogManager.getLogger(UserController.class);

    @Autowired
    private UserService userService;

    @PostMapping("/add")
    public UserLogin addUser(@RequestBody UserLogin user) {
        logger.info("Received request to add a new user: {}", user);
        if (user == null) {
            logger.error("ERROR: User object is null");
            throw new IllegalArgumentException("User cannot be null");
        }
        userService.addUser(user);
        logger.debug("User added successfully: {}", user);
        return user;
    }

    @GetMapping
    public List<UserLogin> getAllUser() {
        logger.info("Fetching all users");
        List<UserLogin> users = userService.getAllUser();
        if (users.isEmpty()) {
            logger.warn("No users found in the system");
        }
        logger.debug("Total users found: {}", users.size());
        return users;
    }

    @GetMapping("/{email}")
    public UserLogin getUserByEmailId(@PathVariable String email) {
        logger.info("Fetching user by email: {}", email);
        if (email == null || email.isEmpty()) {
            logger.error("ERROR: Email parameter is null or empty");
            throw new IllegalArgumentException("Email cannot be empty");
        }
        UserLogin user = userService.getUserByEmailId(email);
        if (user == null) {
            logger.warn("User not found with email: {}", email);
        } else {
            logger.debug("User details retrieved: {}", user);
        }
        return user;
    }

    @GetMapping("/id/{id}")
    public Optional<UserLogin> getUserById(@PathVariable int id) {
        logger.info("Fetching user by ID: {}", id);
        if (id <= 0) {
            logger.error("ERROR: Invalid user ID provided: {}", id);
            throw new IllegalArgumentException("User ID must be greater than zero");
        }
        Optional<UserLogin> user = userService.getUserByid(id);
        if (user.isEmpty()) {
            logger.warn("No user found with ID: {}", id);
        } else {
            logger.debug("User found: {}", user.get());
        }
        return user;
    }

    @DeleteMapping("/{email}")
    public void removeUserByEmail(@PathVariable String email) {
        logger.info("Deleting user with email: {}", email);
        if (email == null || email.isEmpty()) {
            logger.error("ERROR: Email parameter is null or empty");
            throw new IllegalArgumentException("Email cannot be empty");
        }
        UserLogin user = userService.getUserByEmailId(email);
        if (user == null) {
            logger.warn("User with email {} not found for deletion", email);
            throw new RuntimeException("User not found");
        }
        userService.removeByEmail(email);
        logger.debug("User with email {} deleted successfully", email);
    }

    @PutMapping("/update/{email}")
    public UserLogin updateUserByEmail(@PathVariable String email, @RequestBody UserLogin user) {
        logger.info("Updating user with email: {}", email);
        if (email == null || email.isEmpty() || user == null) {
            logger.error("ERROR: Email or user object is null/empty");
            throw new IllegalArgumentException("Email and user object cannot be null or empty");
        }
        UserLogin existingUser = userService.getUserByEmailId(email);
        if (existingUser == null) {
            logger.warn("User with email {} not found for update", email);
            throw new RuntimeException("User not found");
        }
        userService.updateUserByEmail(email, user);
        logger.debug("User with email {} updated successfully", email);
        return userService.getUserByEmailId(email);
    }
}
