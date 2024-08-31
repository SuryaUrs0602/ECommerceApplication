namespace ECommerceCompanyApplication.Models
{
    public class OrderDTO
    {
        public int OrderID { get; set; }
        public string ProductName { get; set; } = string.Empty;

        public double OrderPrice { get; set; }

        public int CustomerID { get; set; }
    }
}
