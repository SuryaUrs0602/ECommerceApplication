using System.ComponentModel.DataAnnotations;

namespace ECommerceCompanyApplication.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        //[MaxLength()] can also be used in case of [stringLength]
        //[MinLength()] can also be used it is used in case of validation of requried number of character.
        [StringLength(20)]
        public string CustomerName { get; set; } = string.Empty;

        [StringLength(30)]
        public string CustomerLocation { get; set; } = string.Empty;

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
