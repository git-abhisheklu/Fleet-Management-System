package com.example.Services;

import java.util.List;
import java.util.Optional;

import com.example.Models.CustomerMaster;

public interface CustomerService 
{
	void addCustomer(CustomerMaster customer);
	 List<CustomerMaster> getAllCustomers();
	 Optional<CustomerMaster> getCustomerByEmailId(String email);
	 Optional<CustomerMaster> getCustomerByid(Long id);
	 void updateCustomer(Long id, CustomerMaster updatedCustomer);
	 void deleteCustomer(Long id);
	// boolean login(String email,String password);
}
