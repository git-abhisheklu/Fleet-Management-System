package com.example.services;

import static org.junit.jupiter.api.Assertions.*;
import static org.mockito.Mockito.*;

import java.util.Arrays;
import java.util.List;
import java.util.Optional;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.ArgumentCaptor;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.junit.jupiter.MockitoExtension;

import com.example.Models.UserLogin;
import com.example.Repositories.UserRepository;
import com.example.Services.UserServiceImpl;

@ExtendWith(MockitoExtension.class)
public class UserServiceTest {

    @Mock
    private UserRepository userRepository;

    @InjectMocks
    private UserServiceImpl userService;

    private UserLogin user;

    @BeforeEach
    void setUp() {
        user = new UserLogin();
        user.setUserid(1L);
        user.setUserName("John025");
        user.setFirstName("John");
        user.setLastName("Doe");
        user.setEmail("john@example.com");
        user.setPassword("password123");
        user.setRole("User");
    }

    @Test
    void testAddUser() {
        when(userRepository.save(any(UserLogin.class))).thenReturn(user);

        userService.addUser(user);

        verify(userRepository, times(1)).save(user);
    }

    @Test
    void testGetAllUsers() {
        List<UserLogin> userList = Arrays.asList(
            user, 
            new UserLogin(2L, "Jane25", "Doe", "jane@example.com", "password456", "jane", "User")
        );
        when(userRepository.findAll()).thenReturn(userList);

        List<UserLogin> retrievedUsers = userService.getAllUser();

        assertNotNull(retrievedUsers);
        assertEquals(2, retrievedUsers.size());
    }

    @Test
    void testGetUserByEmailId() {
        when(userRepository.findByEmail("john@example.com")).thenReturn(user);

        UserLogin retrievedUser = userService.getUserByEmailId("john@example.com");

        assertNotNull(retrievedUser);
        assertEquals("John025", retrievedUser.getUserName()); // Corrected Expected Value
    }

    @Test
    void testGetUserById() {
        when(userRepository.findById(1L)).thenReturn(Optional.of(user));

        Optional<UserLogin> retrievedUser = userService.getUserByid(1);

        assertTrue(retrievedUser.isPresent());
        assertEquals("John025", retrievedUser.get().getUserName()); // Corrected Expected Value
//        assertEquals("JohnXYZ", retrievedUser.get().getUserName());        //This will fail
    }

    @Test
    void testRemoveByEmail() {
        when(userRepository.findByEmail("john@example.com")).thenReturn(user);

        userService.removeByEmail("john@example.com");

        verify(userRepository, times(1)).delete(user);
    }

    @Test
    void testUpdateUserByEmail() {
        UserLogin updatedUser = new UserLogin();
        updatedUser.setUserName("John Updated");
        updatedUser.setLastName("Doe Updated");
        updatedUser.setPassword("newpassword");

        when(userRepository.findByEmail("john@example.com")).thenReturn(user);
        when(userRepository.save(any(UserLogin.class))).thenReturn(updatedUser);

        userService.updateUserByEmail("john@example.com", updatedUser);

        // Capture the saved user object
        ArgumentCaptor<UserLogin> userCaptor = ArgumentCaptor.forClass(UserLogin.class);
        verify(userRepository).save(userCaptor.capture());

        UserLogin capturedUser = userCaptor.getValue();
        assertEquals("John Updated", capturedUser.getUserName());
        assertEquals("Doe Updated", capturedUser.getLastName());
        assertEquals("newpassword", capturedUser.getPassword());
    }
}
