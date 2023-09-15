
using System.ComponentModel.DataAnnotations;

namespace Resto.API.Model.Domain
{
    public class Transaction
    {
        [Key]
        public int TransId { get; set; }
        public int OrderId { get; set; }
        //public Guid FoodId { get; set; }
        public DateTime? TransactionDate { get; set; }

    }
}
