using ECommerceCompanyApplication.Models;
using ECommerceCompanyApplication.Services.Contracts;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;

namespace ECommerceCompanyApplication.Controllers
{
    [EnableCors("myPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var customers = await _customerService.GetAllValues();
            Console.WriteLine(customers);
            return Ok(customers);
        }

        [HttpGet("{CustomerID}")]
        public async Task<IActionResult> GetCustomer(int CustomerID)
        {
            var customer = await _customerService.GetValue(CustomerID);
            if (customer == null)
                return NotFound();
            return Ok(customer);
        }

        [HttpDelete("{CustomerID}")]
        public async Task<IActionResult> DeleteData(int CustomerID)
        {
            await _customerService.DeleteData(CustomerID);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> AddData(CustomerDTO customerDto)
        {
            var customer = new Customer
            {
                CustomerName = customerDto.CustomerName,
                CustomerLocation = customerDto.CustomerLocation,
            };

            await _customerService.AddData(customer);
            return Created();
        }

        [HttpPut("{CustomerID}")]
        public async Task<IActionResult> EditData(int CustomerID, CustomerDTO customerDto)
        {
            var customer = new Customer
            {
                CustomerID = customerDto.CustomerID,
                CustomerName = customerDto.CustomerName,
                CustomerLocation = customerDto.CustomerLocation,
            };

            await _customerService.EditData(CustomerID, customer);
            return NoContent();
        }

        [HttpGet("sort/asc")]
        public async Task<IActionResult> SortAscending()
        {
            var customer = await _customerService.SortAsc();
            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        [HttpGet("sort/desc")]
        public async Task<IActionResult> SortDescending()
        {
            var customer = await _customerService.SortDesc();
            if (customer == null)
                return NotFound();
            return Ok(customer);
        }

        [HttpGet("withorders")]
        public async Task<IActionResult> DisplayCustomersWithOrders()
        {
            var customerWithOrders = await _customerService.CustomersWithOrders();
            return Ok(customerWithOrders);  
        }

        [HttpGet("groupbylocation")]
        public async Task<IActionResult> GroupingByLocation()
        {
            var groupedCustomers = await _customerService.GroupBy();
            return Ok(groupedCustomers);
        }
    }
}
