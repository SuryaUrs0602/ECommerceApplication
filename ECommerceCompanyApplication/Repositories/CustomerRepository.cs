using ECommerceCompanyApplication.Controllers;
using ECommerceCompanyApplication.Models;
using ECommerceCompanyApplication.Repositories;
using ECommerceCompanyApplication.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ECommerceCompanyApplication.Repositories
{
    public class CustomerRepository : GenericRepository<Customer> , ICustomerRepository
    {
        private readonly ECommerceDbContext _dbContext;

        public CustomerRepository(ECommerceDbContext context) : base(context) 
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<Customer>> SortAscending()
        {
            return await _dbContext.Customers.OrderBy(customer => customer.CustomerName).ToListAsync();
        }

        public async Task<IEnumerable<Customer>> SortDescending()
        {
            return await _dbContext.Customers.OrderByDescending(customer => customer.CustomerName).ToListAsync();
        }

        public async Task<List<Customer>> WithOrders()
        {
            //customer with most orders

            //var customerWithMostOrder = await _dbContext.Customers
            //    .Select(customer => new
            //    {
            //        Customer = customer,
            //        OrderCount = customer.Orders.Count()
            //    })
            //    .OrderByDescending(order => order.OrderCount)
            //    .Select(c => c.Customer.CustomerID)
            //    .FirstOrDefaultAsync();

            //var customersWithOrders = await _dbContext.Customers
            //    .Include(customer => customer.Orders)
            //    .Where(c => c.CustomerID == customerWithMostOrder)
            //    .ToListAsync();

            //Customers with orders

            var customersWithOrders = await _dbContext.Customers
                .Include(o => o.Orders)
                .Where(c => c.Orders.Any())
                .ToListAsync();

            return customersWithOrders;
        }

        public async Task<IEnumerable<dynamic>> GroupByLocation()
        {
            var groupedCustomers = await _dbContext.Customers
                .GroupBy(customer => customer.CustomerLocation)
                .Select(group => new
                 {
                    location = group.Key,
                    count = group.Count(),
                    customer = group.ToList()
                 }).ToListAsync();

            return groupedCustomers;
        }
    }
}
