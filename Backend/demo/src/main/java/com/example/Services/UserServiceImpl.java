package com.example.Services;

import java.util.List;
import java.util.Optional;

import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.example.Models.UserLogin;
import com.example.Repositories.UserRepository;

@Service
public class UserServiceImpl implements UserService {

    private static final Logger logger = LogManager.getLogger(UserServiceImpl.class);

    @Autowired
    private UserRepository userRepos;

    @Override
    public void addUser(UserLogin user) {
        logger.info("Attempting to add a new user: {}", user.getEmail());
        userRepos.save(user);
        logger.info("User added successfully: {}", user.getEmail());
    }

    @Override
    public List<UserLogin> getAllUser() {
        logger.info("Fetching all users from the database...");
        List<UserLogin> users = userRepos.findAll();
        logger.info("Total users found: {}", users.size());
        return users;
    }

    @Override
    public UserLogin getUserByEmailId(String email) {
        logger.info("Searching for user with email: {}", email);
        UserLogin user = userRepos.findByEmail(email);
        if (user == null) {
            logger.error("User not found with email: {}", email);
        } else {
            logger.info("User found: {}", user);
        }
        return user;
    }

    @Override
    public Optional<UserLogin> getUserByid(int id) {
        logger.info("Searching for user with ID: {}", id);
        Optional<UserLogin> user = userRepos.findById((long) id);
        if (user.isEmpty()) {
            logger.error("No user found with ID: {}", id);
        } else {
            logger.info("User found: {}", user.get());
        }
        return user;
    }

    @Override
    public void removeByEmail(String email) {
        logger.info("Attempting to remove user with email: {}", email);
        UserLogin user = userRepos.findByEmail(email);
        if (user != null) {
            userRepos.delete(user);
            logger.info("User deleted successfully: {}", email);
        } else {
            logger.error("No user found with email: {}", email);
        }
    }

    @Override
    public void updateUserByEmail(String email, UserLogin user) {
        logger.info("Attempting to update user with email: {}", email);
        UserLogin existingUser = userRepos.findByEmail(email);
        if (existingUser != null) {
            logger.debug("Old User Data: {}", existingUser);
            existingUser.setUserName(user.getUserName());
            existingUser.setLastName(user.getLastName());
            existingUser.setPassword(user.getPassword());
            userRepos.save(existingUser);
            logger.info("User updated successfully: {}", email);
        } else {
            logger.error("Update failed. No user found with email: {}", email);
        }
    }
}
