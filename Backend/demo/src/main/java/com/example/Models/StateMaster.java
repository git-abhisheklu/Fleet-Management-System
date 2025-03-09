package com.example.Models;

import jakarta.persistence.*;

@Entity
public class StateMaster {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long stateId;
   
    @Column(unique=true)
    private String stateName;
    
 
    public StateMaster() {
    }

  
    public StateMaster(String stateName) {
        this.stateName = stateName;
    }
    
    
    public Long getStateId() {
        return stateId;
    }

    public void setStateId(Long stateId) {
        this.stateId = stateId;
    }

    public String getStateName() {
        return stateName;
    }

    public void setStateName(String stateName) {
        this.stateName = stateName;
    }


	@Override
	public String toString() {
		return "StateMaster [stateId=" + stateId + ", stateName=" + stateName + "]";
	}


	public StateMaster(Long stateId, String stateName) {
		super();
		this.stateId = stateId;
		this.stateName = stateName;
	}
}



