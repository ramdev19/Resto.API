using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Resto.API.Model.Domain.DTO
{
    public class FoodDto
    {
        [Key]
        public Guid Id { get; set; }
        [Column(TypeName = "VARCHAR(100)")]
        public string FoodName { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal FoodPrice { get; set; }
        [Column(TypeName = "VARCHAR(250)")]
        public string FoodDescription { get; set; }
    }
}
