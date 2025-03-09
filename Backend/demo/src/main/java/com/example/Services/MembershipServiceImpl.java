package com.example.Services;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.example.Models.CustomerMaster;
import com.example.Models.Membership;
import com.example.Repositories.CustomerRepository;
import com.example.Repositories.MembershipRepository;

@Service
public class MembershipServiceImpl implements MembershipService{
	
	@Autowired
	private MembershipRepository membershipRepository;

	@Autowired
	private CustomerRepository customerRepository;
	@Override
	public Membership createMembership(Membership membership) {
	    // Fetch the complete CustomerMaster object using customerId
	    Long customerId = membership.getCustomer().getCustomerId(); 
	    Optional<CustomerMaster> customer = customerRepository.findById(customerId);

	    if (customer.isPresent()) {
	        membership.setCustomer(customer.get()); // Set the full Customer object
	    } else {
	        throw new RuntimeException("Customer with ID " + customerId + " not found.");
	    }

	    return membershipRepository.save(membership);
	}

	@Override
	public Optional<Membership> getMembershipById(Long membershipId) {
		
		return membershipRepository.findById(membershipId);
	}

	@Override
	public List<Membership> getAllMemberships() {
	
		return membershipRepository.findAll();
	}

	@Override
	public List<Membership> getMembershipByCustomerId(Long customerId) {
		
		return membershipRepository.findByCustomerCustomerId(customerId);
	}

	@Override
	public Membership updateMembership(Long membershipId, Membership updatedMembership) {
		
		 return membershipRepository.findById(membershipId).map(existingMembership -> {
	            existingMembership.setMembershipType(updatedMembership.getMembershipType());
	            existingMembership.setFee(updatedMembership.getFee());
	            existingMembership.setStartDate(updatedMembership.getStartDate());
	            existingMembership.setEndDate(updatedMembership.getEndDate());
	            return membershipRepository.save(existingMembership);
	        }).orElseThrow(() -> new RuntimeException("Membership not found"));
	}

	@Override
	public void deleteMembership(Long membershipId) {
		membershipRepository.deleteById(membershipId);
		
	}

}
