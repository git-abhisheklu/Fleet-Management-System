package com.example.Repositories;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.example.Models.InvoiceHeader;

@Repository
public interface InvoiceHeaderRepository extends JpaRepository<InvoiceHeader, Long> {

}
