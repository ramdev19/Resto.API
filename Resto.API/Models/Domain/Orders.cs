using Resto.API.Model.Domain;

namespace Resto.API.Models.Domain
{
    public class Orders
    {
        public int OrderID { get; set; }
        public DateTime? OrderDate { get; set; }
        public Guid CustomerID { get; set; }
        public decimal TotalPayment { get; set; }
        public DateTime? TransactionDate { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
    }
}
