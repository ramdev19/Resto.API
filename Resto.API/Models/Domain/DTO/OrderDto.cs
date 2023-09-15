using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Resto.API.Model.Domain;

namespace Resto.API.Models.Domain.DTO
{
    public class OrderDto
    {

        public int OrderId { get; set; }

        public Guid CustomerId { get; set; }
        public decimal TotalPayment { get; set; }
        public DateTime? OrderDate { get; set; }

        // Navigate

        public CustomerDto Customer { get; set; }
        public List<OrderDetailDto> OrderDetailDto { get; set; }


    }
}
