package com.example.Repositories;

import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import com.example.Models.CustomerMaster;

import jakarta.transaction.Transactional;

@Repository
public interface CustomerRepository extends JpaRepository<CustomerMaster,Long>{
	
	@Query(value = "SELECT * FROM customer_master WHERE email = :email", nativeQuery = true)
	Optional<CustomerMaster> getCustomerByEmailId(@Param("email") String email);
	
	@Query(value = "SELECT * FROM customer_master WHERE customer_id = :id", nativeQuery = true)
	Optional<CustomerMaster> getCustomerById(@Param("id") Long customerId);
	
	@Transactional
    @Modifying
    @Query(value = "UPDATE customer_master SET first_name = :firstName, last_name = :lastName, email = :email WHERE customer_id = :id", nativeQuery = true)
    void updateCustomer(@Param("id") Long id, @Param("firstName") String firstName, @Param("lastName") String lastName, @Param("email") String email);
	
	 @Transactional
	 @Modifying
	 @Query(value = "DELETE FROM customer_master WHERE customer_id = :id", nativeQuery = true)
	 void deleteCustomer(@Param("id") Long id);
	 
//	 @Query(value = "SELECT COUNT(*) FROM customer_master WHERE email = :email AND password = :password", nativeQuery = true)
//	    Long login(@Param("email") String email, @Param("password") String password);
}
