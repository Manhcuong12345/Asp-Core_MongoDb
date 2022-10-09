using System.Collections.Generic;
using System.Threading.Tasks;
using Project_Test.Models;
using Project_Test.Repository;

namespace Project_Test.Services
{
    public class CustomerService : ICustomerService
    {
        //SU dung lop ben customerRepository de su dung trong nay
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Task<List<Customer>> GetAllAsync()
        {
            return _customerRepository.GetAllAsync();
        }

        public Task<Customer> GetByIdAsync(string id)
        {
            return _customerRepository.GetByIdAsync(id);
        }

        public Task<Customer> CreateAsync(Customer customer)
        {
            return _customerRepository.CreateAsync(customer);
        }

        public Task UpdateAsync(string id, Customer customer)
        {
            return _customerRepository.UpdateAsync(id, customer);
        }

        public Task DeleteAsync(string id)
        {
            return _customerRepository.DeleteAsync(id);
        }
    }
}
