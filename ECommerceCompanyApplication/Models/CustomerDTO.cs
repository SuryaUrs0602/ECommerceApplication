namespace ECommerceCompanyApplication.Models
{
    public class CustomerDTO
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; } = string.Empty;

        public string CustomerLocation { get; set; } = string.Empty;
    }
}
