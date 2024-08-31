using ECommerceCompanyApplication.Models;
using ECommerceCompanyApplication.Repositories;
using ECommerceCompanyApplication.Repositories.Contracts;

namespace ECommerceCompanyApplication.Services.Contracts
{
    public interface ICustomerService : IGenericRepository<Customer>
    {
        Task<IEnumerable<dynamic>> GroupBy();

        Task<IEnumerable<Customer>> SortAsc();

        Task<IEnumerable<Customer>> SortDesc();

        Task<List<Customer>> CustomersWithOrders();
    }
}
