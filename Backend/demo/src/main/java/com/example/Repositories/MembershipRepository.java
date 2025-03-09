package com.example.Repositories;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;

import com.example.Models.Membership;

public interface MembershipRepository extends JpaRepository<Membership, Long>{
	List<Membership> findByCustomerCustomerId(Long customerId);
}
