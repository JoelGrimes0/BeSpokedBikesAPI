using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeSpokedBikesAPI.Models
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SalespersonId { get; set; }
        public int CustomerId { get; set; }
        public DateTime SalesDate { get; set; }
        public decimal SalePrice { get; set; }

        [ForeignKey("ProductId")]
        public Product? Product { get; set; }

        [ForeignKey("SalespersonId")]
        public Salesperson? Salesperson { get; set; }

        [ForeignKey("CustomerId")]
        public Customer? Customer { get; set; }
        public decimal SalespersonCommission => (SalePrice * Product.CommissionPercentage) / 100;
    }
}
