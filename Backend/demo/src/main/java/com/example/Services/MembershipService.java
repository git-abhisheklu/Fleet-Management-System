package com.example.Services;

import java.util.List;
import java.util.Optional;

import com.example.Models.Membership;

public interface MembershipService {
	
	Membership createMembership(Membership membership);
	Optional<Membership> getMembershipById(Long membershipId);
	List<Membership> getAllMemberships();
	List<Membership> getMembershipByCustomerId(Long customerId);
	Membership updateMembership(Long membershipId,Membership updateMembership);
	void deleteMembership(Long membershipId);
	
}
