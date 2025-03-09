using Fleet_Management.Models;
using Fleet_Management.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Fleet_Management.DTO;

namespace Fleet_Management.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly FleetDbContext _context;

        public CustomerService(FleetDbContext context)
        {
            _context = context;
        }

        public async Task AddCustomer(CustomerDTO newCustomerDto)
        {
            var newCustomer = new CustomerMaster
            {
                FirstName = newCustomerDto.FirstName,
                LastName = newCustomerDto.LastName,
                AddressLine1 = newCustomerDto.AddressLine1,
                AddressLine2 = newCustomerDto.AddressLine2,
                Email = newCustomerDto.Email,
                City = newCustomerDto.City,
                Pincode = newCustomerDto.Pincode,
                PhoneNumber = newCustomerDto.PhoneNumber,
                MobileNumber = newCustomerDto.MobileNumber,
                CreditCardType = newCustomerDto.CreditCardType,
                CreditCardNumber = newCustomerDto.CreditCardNumber,
                DrivingLicenseNumber = newCustomerDto.DrivingLicenseNumber,
                IdpNumber = newCustomerDto.IdpNumber,
                IssuedBydl = newCustomerDto.IssuedByDL,
                ValidThroughdl = newCustomerDto.ValidThroughDL,
                PassportNumber = newCustomerDto.PassportNumber,
                PassportValidThrough = newCustomerDto.PassportValidThrough,
                PassportIssuedBy = newCustomerDto.PassportIssuedBy,
                PassportValidFrom = newCustomerDto.PassportValidFrom,
                PassportIssueDate = newCustomerDto.PassportIssueDate,
                DateOfBirth = newCustomerDto.DateOfBirth
            };

            await _context.CustomerMasters.AddAsync(newCustomer);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<CustomerDTO>> GetAllCustomers()
        {
            var customers = await _context.CustomerMasters.ToListAsync();

            return customers.Select(customer => new CustomerDTO
            {
                CustomerId = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                AddressLine1 = customer.AddressLine1,
                AddressLine2 = customer.AddressLine2,
                Email = customer.Email,
                City = customer.City,
                Pincode = customer.Pincode,
                PhoneNumber = customer.PhoneNumber,
                MobileNumber = customer.MobileNumber,
                CreditCardType = customer.CreditCardType,
                CreditCardNumber = customer.CreditCardNumber,
                DrivingLicenseNumber = customer.DrivingLicenseNumber,
                IdpNumber = customer.IdpNumber,
                IssuedByDL = customer.IssuedBydl,
                ValidThroughDL = customer.ValidThroughdl,
                PassportNumber = customer.PassportNumber,
                PassportValidThrough = customer.PassportValidThrough,
                PassportIssuedBy = customer.PassportIssuedBy,
                PassportValidFrom = customer.PassportValidFrom,
                PassportIssueDate = customer.PassportIssueDate,
                DateOfBirth = customer.DateOfBirth
            });
        }

        public async Task<CustomerDTO?> GetCustomerById(long id)
        {
            var customer = await _context.CustomerMasters.FindAsync(id);
            if (customer == null) return null;

            return new CustomerDTO
            {
                CustomerId = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                AddressLine1 = customer.AddressLine1,
                AddressLine2 = customer.AddressLine2,
                Email = customer.Email,
                City = customer.City,
                Pincode = customer.Pincode,
                PhoneNumber = customer.PhoneNumber,
                MobileNumber = customer.MobileNumber,
                CreditCardType = customer.CreditCardType,
                CreditCardNumber = customer.CreditCardNumber,
                DrivingLicenseNumber = customer.DrivingLicenseNumber,
                IdpNumber = customer.IdpNumber,
                IssuedByDL = customer.IssuedBydl,
                ValidThroughDL = customer.ValidThroughdl,
                PassportNumber = customer.PassportNumber,
                PassportValidThrough = customer.PassportIssueDate,
                PassportIssuedBy = customer.PassportIssuedBy,
                PassportValidFrom = customer.PassportValidFrom,
                PassportIssueDate = customer.PassportIssueDate,
                DateOfBirth = customer.DateOfBirth
            };
        }

        public async Task<CustomerDTO?> GetCustomerByEmail(string email)
        {
            var customer = await _context.CustomerMasters.FirstOrDefaultAsync(c => c.Email == email);
            if (customer == null) return null;

            return new CustomerDTO
            {
                CustomerId = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                AddressLine1 = customer.AddressLine1,
                AddressLine2 = customer.AddressLine2,
                Email = customer.Email,
                City = customer.City,
                Pincode = customer.Pincode,
                PhoneNumber = customer.PhoneNumber,
                MobileNumber = customer.MobileNumber,
                CreditCardType = customer.CreditCardType,
                CreditCardNumber = customer.CreditCardNumber,
                DrivingLicenseNumber = customer.DrivingLicenseNumber,
                IdpNumber = customer.IdpNumber,
                IssuedByDL = customer.IssuedBydl,
                ValidThroughDL = customer.ValidThroughdl,
                PassportNumber = customer.PassportNumber,
                PassportValidThrough = customer.PassportValidThrough,
                PassportIssuedBy = customer.PassportIssuedBy,
                PassportValidFrom = customer.PassportValidFrom,
                PassportIssueDate = customer.PassportIssueDate,
                DateOfBirth = customer.DateOfBirth,
            };
        }

        public async Task UpdateCustomer(long id, CustomerDTO updatedCustomerDto)
        {
            var existingCustomer = await _context.CustomerMasters.FindAsync(id);

            if (existingCustomer == null)
                return;

            existingCustomer.FirstName = updatedCustomerDto.FirstName;
            existingCustomer.LastName = updatedCustomerDto.LastName;
            existingCustomer.AddressLine1 = updatedCustomerDto.AddressLine1;
            existingCustomer.AddressLine2 = updatedCustomerDto.AddressLine2;
            existingCustomer.Email = updatedCustomerDto.Email;
            existingCustomer.City = updatedCustomerDto.City;
            existingCustomer.Pincode = updatedCustomerDto.Pincode;
            existingCustomer.PhoneNumber = updatedCustomerDto.PhoneNumber;
            existingCustomer.MobileNumber = updatedCustomerDto.MobileNumber;
            existingCustomer.CreditCardType = updatedCustomerDto.CreditCardType;
            existingCustomer.CreditCardNumber = updatedCustomerDto.CreditCardNumber;
            existingCustomer.DrivingLicenseNumber = updatedCustomerDto.DrivingLicenseNumber;
            existingCustomer.IdpNumber = updatedCustomerDto.IdpNumber;
            existingCustomer.IssuedBydl = updatedCustomerDto.IssuedByDL;
            existingCustomer.ValidThroughdl = updatedCustomerDto.ValidThroughDL;
            existingCustomer.PassportNumber = updatedCustomerDto.PassportNumber;
            existingCustomer.PassportValidThrough = updatedCustomerDto.PassportValidThrough;
            existingCustomer.PassportIssuedBy = updatedCustomerDto.PassportIssuedBy;
            existingCustomer.PassportValidFrom = updatedCustomerDto.PassportValidFrom;
            existingCustomer.PassportIssueDate = updatedCustomerDto.PassportIssueDate;
            existingCustomer.DateOfBirth = updatedCustomerDto.DateOfBirth;

            _context.CustomerMasters.Update(existingCustomer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCustomer(long id)
        {
            var customer = await _context.CustomerMasters.FindAsync(id);

            if (customer == null)
                return;

            // Delete related records first
            await _context.InvoiceHeaders.Where(i => i.CustomerId == id).ExecuteDeleteAsync();
            await _context.Memberships.Where(m => m.CustomerId == id).ExecuteDeleteAsync();
            await _context.Bookings.Where(b => b.CustomerId == id).ExecuteDeleteAsync();

            // Now delete the customer
            _context.CustomerMasters.Remove(customer);
            await _context.SaveChangesAsync();
        }
    }
}
