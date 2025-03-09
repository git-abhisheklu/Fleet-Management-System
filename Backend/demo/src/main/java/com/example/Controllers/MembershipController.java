package com.example.Controllers;

import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.example.Models.CustomerMaster;
import com.example.Models.Membership;
import com.example.Services.MembershipService;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestParam;



@RestController
@RequestMapping("/api/membership")
@CrossOrigin(origins = "http://localhost:3000")
public class MembershipController {
	
	@Autowired
     private MembershipService membershipService;
     
     @PostMapping("/create")
     public Membership createMembership(@RequestBody Membership membership) {
        
         return membershipService.createMembership(membership);
     }
     
     @GetMapping("/{membershipId}")
     public Optional<Membership> getMembershipById(@PathVariable Long membershipId) {
         return membershipService.getMembershipById(membershipId);
     }
     
     @GetMapping("/all")
     public List<Membership> getAllMembership(){
    	 return membershipService.getAllMemberships();
     }
     
     @GetMapping("/customer/{customerId}")
     
     public List<Membership> getMembershipsByCustomerId(@PathVariable Long customerId){
    	 return membershipService.getMembershipByCustomerId(customerId);
    	 
     }
     
     
     @PutMapping("/update/{membershipId}")
     public Membership updateMembership(@PathVariable Long membershipId ,@RequestBody Membership updatedMembership ) {
    	 return membershipService.updateMembership(membershipId, updatedMembership);
     }
     
     @DeleteMapping("/delete/{membershipId}")
     public void deleteMembership(@PathVariable Long membershipId) {
    	  membershipService.deleteMembership(membershipId);
     }
     
}
