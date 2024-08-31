using ECommerceCompanyApplication.Models;
using ECommerceCompanyApplication.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ECommerceCompanyApplication.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly ECommerceDbContext _context;

        public OrderRepository(ECommerceDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> Filter(string ProductName)
        {
            return await _context.Orders.Where(order => order.ProductName == ProductName).ToListAsync();
        }

        public async Task<IEnumerable<Order>> SortAsc()
        {
            return await _context.Orders.OrderBy(order => order.OrderPrice).ToListAsync();
        }

        public async Task<IEnumerable<Order>> SortDesc()
        {
            return await _context.Orders.OrderByDescending(order => order.OrderPrice).ToListAsync();
        }
    }
}
