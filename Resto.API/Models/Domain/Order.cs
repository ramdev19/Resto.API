using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resto.API.Model.Domain
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public Guid CustomerId { get; set; }
        [Column(TypeName ="decimal(18,4)")]
        public decimal TotalPayment { get; set; }
        public DateTime? OrderDate { get; set; }
        
    }
}
