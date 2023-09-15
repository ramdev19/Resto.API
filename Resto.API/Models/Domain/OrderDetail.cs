using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resto.API.Model.Domain
{
    public class OrderDetails
    {
        [Key]
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        
        public Guid FoodId { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName ="decimal(18,4)")]
        public decimal Amount { get; set; }


     
    }
}
