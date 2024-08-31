using ECommerceCompanyApplication.Models;

namespace ECommerceCompanyApplication.Repositories.Contracts
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<IEnumerable<Order>> Filter(string ProductName);

        Task<IEnumerable<Order>> SortAsc();

        Task<IEnumerable<Order>> SortDesc();
    }
}
