using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECommerceCompanyApplication.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        [StringLength(30)]
        public string ProductName { get; set; } = string.Empty;

        public double OrderPrice { get; set; }

        public DateTime OrderDate { get; set; }

        public int CustomerID { get; set; }

        public virtual Customer? Customer { get; set; }
    }
}
