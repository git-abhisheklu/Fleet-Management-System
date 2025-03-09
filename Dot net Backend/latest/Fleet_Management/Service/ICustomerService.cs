using Fleet_Management.DTO;
using Fleet_Management.Models;

namespace Fleet_Management.Service
{
    public interface ICustomerService
    {
        Task AddCustomer(CustomerDTO newCustomerDto);
        Task<IEnumerable<CustomerDTO>> GetAllCustomers();
        Task<CustomerDTO?> GetCustomerById(long id);
        Task<CustomerDTO?> GetCustomerByEmail(string email);
        Task UpdateCustomer(long id, CustomerDTO updatedCustomerDto);
        Task DeleteCustomer(long id);
    }
}
