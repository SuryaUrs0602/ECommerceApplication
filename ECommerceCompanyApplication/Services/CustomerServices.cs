using ECommerceCompanyApplication.Models;
using ECommerceCompanyApplication.Repositories;
using ECommerceCompanyApplication.Repositories.Contracts;
using ECommerceCompanyApplication.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ECommerceCompanyApplication.Services
{
    public class CustomerServices : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerServices(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;            
        }

        public async Task AddData(Customer obj)
        {
            await _customerRepository.AddData(obj);
        }

        public async Task DeleteData(object ID)
        {
            await _customerRepository.DeleteData(ID);
        }

        public async Task EditData(object ID, Customer obj)
        {
            await _customerRepository.EditData(ID, obj);
        }

        public Task<IEnumerable<Customer>> GetAllValues()
        {
            return _customerRepository.GetAllValues();
        }

        public async Task<Customer> GetValue(object ID)
        {
            return await _customerRepository.GetValue(ID);
        }

        public async Task<IEnumerable<dynamic>> GroupBy()
        {
            return await _customerRepository.GroupByLocation();
        }

        public async Task<IEnumerable<Customer>> SortAsc()
        {
            return await _customerRepository.SortAscending();
        }

        public async Task<IEnumerable<Customer>> SortDesc()
        {
            return await _customerRepository.SortDescending();
        }

        public async Task<List<Customer>> CustomersWithOrders()
        {
            return await _customerRepository.WithOrders();
        }
    }
}
