using Resto.API.Model.Domain.DTO;
namespace Resto.API.Models.Domain.DTO
{
    public class TransactionDto
    {

        public int TransId { get; set; }
        public int OrderId { get; set; }
        public DateTime? TransactionDate { get; set; }




        //Navigate 
        public OrderDto Order { get; set; }
        //public FoodDto Food { get; set; }

    }
}