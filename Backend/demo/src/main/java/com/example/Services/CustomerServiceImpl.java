package com.example.Services;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.example.Models.CustomerMaster;
import com.example.Repositories.CustomerRepository;

@Service
public class CustomerServiceImpl implements CustomerService{
	@Autowired
	private CustomerRepository c_repository;
	

	public void addCustomer(CustomerMaster customer) {
		// TODO Auto-generated method stub
		c_repository.save(customer);
	}

	public List<CustomerMaster> getAllCustomers() {
		// TODO Auto-generated method stub
		return c_repository.findAll();
	}
	
	public Optional<CustomerMaster> getCustomerByEmailId(String email) {
		// TODO Auto-generated method stub
		return c_repository.getCustomerByEmailId(email);
	}

	public Optional<CustomerMaster> getCustomerByid(Long id) {
		// TODO Auto-generated method stub
		return c_repository.findById(id);
	}
	
	 public void updateCustomer(Long id, CustomerMaster updatedCustomer) {
	        c_repository.updateCustomer(id, updatedCustomer.getFirstName(), updatedCustomer.getLastName(), updatedCustomer.getEmail());
	    }
	 
	 public void deleteCustomer(Long id) {
	        c_repository.deleteCustomer(id);
	    }

//	 public boolean login(String email, String password) {
//		 int count = c_repository.login(email, password);
//	        return count > 0;
//	}


}
