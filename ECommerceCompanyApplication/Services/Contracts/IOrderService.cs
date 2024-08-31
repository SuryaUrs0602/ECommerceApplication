using ECommerceCompanyApplication.Models;
using ECommerceCompanyApplication.Repositories.Contracts;

namespace ECommerceCompanyApplication.Services.Contracts
{
    public interface IOrderService : IGenericRepository<Order>
    {
        Task<IEnumerable<Order>> FilterByName(string ProductName);

        Task<IEnumerable<Order>> SortingAsc();

        Task<IEnumerable<Order>> SortingDesc();
    }
}
