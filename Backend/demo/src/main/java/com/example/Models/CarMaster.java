package com.example.Models;

import jakarta.persistence.*;
import lombok.Data;
import lombok.NoArgsConstructor;
import lombok.AllArgsConstructor;

import java.time.LocalDate;

@Entity
@Data 
@NoArgsConstructor 
@AllArgsConstructor 
public class CarMaster {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long carId;  

    @ManyToOne
    @JoinColumn(name = "cartypeId", nullable = false)
    
    private CarTypeMaster cartypeId;  	
    
    private String carName;  
    
    @Column(unique = true)
    private String numberPlate;
    
    private String fuelStatus;
    
    private Double mileage;
    

    @ManyToOne
    @JoinColumn(name = "hubId", nullable = false, referencedColumnName="hubId") 
    private HubMaster hub_id;  // Reference to HubMaster entity
    
    @Enumerated(EnumType.STRING)
    @Column(name = "Is_Available", length = 1)
    private AvailabilityStatus isAvailable;
    
    @Column(nullable = false)
    private LocalDate maintenanceduedate;  
    
    public enum AvailabilityStatus {
        Y, N
    }

	public Long getCarId() {
		return carId;
	}

	public void setCarId(Long carId) {
		this.carId = carId;
	}

	public CarTypeMaster getCarTypeId() {
		return cartypeId;
	}

	public void setCarTypeId(CarTypeMaster carTypeId) {
		this.cartypeId = carTypeId;
	}

	public String getCarName() {
		return carName;
	}

	public void setCarName(String carName) {
		this.carName = carName;
	}

	public String getNumberPlate() {
		return numberPlate;
	}

	public void setNumberPlate(String numberPlate) {
		this.numberPlate = numberPlate;
	}

	public String getFuelStatus() {
		return fuelStatus;
	}

	public void setFuelStatus(String fuelStatus) {
		this.fuelStatus = fuelStatus;
	}

	public HubMaster getHub_id() {
		return hub_id;
	}

	public void setHub_id(HubMaster hub_id) {
		this.hub_id = hub_id;
	}

	public AvailabilityStatus getIsAvailable() {
		return isAvailable;
	}

	public void setIsAvailable(AvailabilityStatus isAvailable) {
		this.isAvailable = isAvailable;
	}

	public LocalDate getMaintenanceduedate() {
		return maintenanceduedate;
	}

	public void setMaintenanceduedate(LocalDate maintenanceduedate) {
		this.maintenanceduedate = maintenanceduedate;
	}

	public CarMaster(Long carId, CarTypeMaster cartypeId, String carName, String numberPlate, String fuelStatus,
			HubMaster hub_id, AvailabilityStatus isAvailable, LocalDate maintenanceduedate) {
		super();
		this.carId = carId;
		this.cartypeId = cartypeId;
		this.carName = carName;
		this.numberPlate = numberPlate;
		this.fuelStatus = fuelStatus;
		this.hub_id = hub_id;
		this.isAvailable = isAvailable;
		this.maintenanceduedate = maintenanceduedate;
	}
    
	public CarMaster() {
		
	}

	@Override
	public String toString() {
		return "CarMaster [carId=" + carId + ", carTypeId=" + cartypeId + ", carName=" + carName + ", numberPlate="
				+ numberPlate + ", fuelStatus=" + fuelStatus + ", hub_id=" + hub_id + ", isAvailable=" + isAvailable
				+ ", maintenanceduedate=" + maintenanceduedate + "]";
	}
	
	
}