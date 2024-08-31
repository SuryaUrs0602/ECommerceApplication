using ECommerceCompanyApplication.Models;
using ECommerceCompanyApplication.Services.Contracts;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceCompanyApplication.Controllers
{
    [EnableCors("myPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderService.GetAllValues();
            return Ok(orders);
        }

        [HttpGet("{OrderID}")]
        public async Task<IActionResult> GetOrder(int OrderID)
        {
            var order = await _orderService.GetValue(OrderID);
            if (order == null)
                return NotFound();
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> Add(OrderDTO orderDto)
        {
            var order = new Order
            {
                ProductName = orderDto.ProductName,
                OrderPrice = orderDto.OrderPrice,
                CustomerID = orderDto.CustomerID,
            };

            await _orderService.AddData(order);
            return Created();
        }

        [HttpDelete("{OrderID}")]
        public async Task<IActionResult> Delete(int OrderID)
        {
            await _orderService.DeleteData(OrderID);
            return NoContent();
        }

        [HttpPut("{OrderID}")]
        public async Task<IActionResult> Edit(int OrderID, OrderDTO orderDto)
        {
            var order = new Order
            {
                OrderID = orderDto.OrderID,
                ProductName = orderDto.ProductName,
                OrderPrice = orderDto.OrderPrice,
                CustomerID = orderDto.CustomerID,
            };

            await _orderService.EditData(OrderID, order);
            return NoContent();
        }

        [HttpGet("filter/{ProductName}")]
        public async Task<IActionResult> Filtering(string ProductName)
        {
            var filteredOrder = await _orderService.FilterByName(ProductName);
            return Ok(filteredOrder);
        }

        [HttpGet("sort/Asc")]
        public async Task<IActionResult> SortAsc()
        {
            var sortAsc = await _orderService.SortingAsc();
            return Ok(sortAsc);
        }

        [HttpGet("sort/Desc")]
        public async Task<IActionResult> SortDesc()
        {
            var sortDesc = await _orderService.SortingDesc();
            return Ok(sortDesc);
        }
    }
}
