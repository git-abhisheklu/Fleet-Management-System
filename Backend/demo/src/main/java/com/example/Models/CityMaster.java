package com.example.Models;

import jakarta.persistence.*;

@Entity
public class CityMaster {
	    @Id
	    @GeneratedValue(strategy = GenerationType.IDENTITY)
	    private Long cityId;

	    private String cityName;

	    @ManyToOne(cascade = CascadeType.ALL,fetch = FetchType.EAGER)
	    @JoinColumn(name = "stateId",referencedColumnName = "stateId", nullable = false )
	    private StateMaster state;
	    
	    
	    
	    public CityMaster() {
	    }

	    // Constructor with fields
	    public CityMaster(String cityName, StateMaster state) {
	        this.cityName = cityName;
	        this.state = state;
	    }
	    public Long getCityId() {
	        return cityId;
	    }

	    public void setCityId(Long cityId) {
	        this.cityId = cityId;
	    }

	    public String getCityName() {
	        return cityName;
	    }

	    public void setCityName(String cityName) {
	        this.cityName = cityName;
	    }

	    public StateMaster getState() {
	        return state;
	    }

	    public void setState(StateMaster state) {
	        this.state = state;
    }

		public CityMaster(Long cityId, String cityName, StateMaster state) {
			super();
			this.cityId = cityId;
			this.cityName = cityName;
			this.state = state;
		}

		@Override
		public String toString() {
			return "CityMaster [cityId=" + cityId + ", cityName=" + cityName + ", state=" + state + "]";
		}
	  
}

