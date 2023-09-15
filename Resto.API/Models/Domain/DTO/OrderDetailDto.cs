using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Resto.API.Model.Domain.DTO;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resto.API.Models.Domain.DTO
{
    public class OrderDetailDto
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }

        public Guid FoodId { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }

        // Navigate

        public OrderDto Order { get; set; }
        public FoodDto Food { get; set; }
    }
}
