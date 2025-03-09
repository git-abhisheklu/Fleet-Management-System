package com.example.Controllers;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.example.Models.CustomerMaster;
import com.example.Services.CustomerServiceImpl;

@RestController
@RequestMapping("api/customers")
@CrossOrigin(origins = "http://localhost:3000")
public class CustomerController {

    @Autowired
    private CustomerServiceImpl c_service;

    @GetMapping
    public List<CustomerMaster> getAllCustomers() {
        return c_service.getAllCustomers();
    }

    @GetMapping("/{id}")
    public Optional<CustomerMaster> getCustomerById(@PathVariable Long id) {
        return c_service.getCustomerByid(id);
    }

    @GetMapping("/email/{email}")
    public Optional<CustomerMaster> getCustomerByEmailId(@PathVariable String email) {
        return c_service.getCustomerByEmailId(email);
    }

    @PostMapping
    public void addCustomer(@RequestBody CustomerMaster customer) {
        c_service.addCustomer(customer);
    }

    @PutMapping("/{id}")
    public void updateCustomer(@PathVariable Long id, @RequestBody CustomerMaster updatedCustomer) {
        c_service.updateCustomer(id, updatedCustomer);
    }

    @DeleteMapping("/{id}")
    public void deleteCustomer(@PathVariable Long id) {
        c_service.deleteCustomer(id);
    }
    
//    @GetMapping("/login/{email}/{password}")
//    public boolean login(@PathVariable String email, @PathVariable String password) {
//        return c_service.login(email, password);
//    }
}