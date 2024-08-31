using ECommerceCompanyApplication.Models;

namespace ECommerceCompanyApplication.Repositories.Contracts
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<IEnumerable<Customer>> SortAscending();

        Task<IEnumerable<Customer>> SortDescending();

        Task<IEnumerable<dynamic>> GroupByLocation();

        Task<List<Customer>> WithOrders();
    }
}
