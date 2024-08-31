using ECommerceCompanyApplication.Models;
using ECommerceCompanyApplication.Repositories.Contracts;
using ECommerceCompanyApplication.Services.Contracts;

namespace ECommerceCompanyApplication.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task AddData(Order obj)
        {
            await _orderRepository.AddData(obj);
        }

        public async Task DeleteData(object ID)
        {
            await _orderRepository.DeleteData(ID);
        }

        public async Task EditData(object ID, Order obj)
        {
            await _orderRepository.EditData(ID, obj);
        }

        public async Task<IEnumerable<Order>> FilterByName(string ProductName)
        {
            return await _orderRepository.Filter(ProductName);
        }

        public async Task<IEnumerable<Order>> GetAllValues()
        {
            return await _orderRepository.GetAllValues();
        }

        public async Task<Order> GetValue(object ID)
        {
            return await _orderRepository.GetValue(ID);
        }

        public async Task<IEnumerable<Order>> SortingAsc()
        {
            return await _orderRepository.SortAsc();
        }

        public async Task<IEnumerable<Order>> SortingDesc()
        {
            return await _orderRepository.SortDesc();
        }
    }
}
