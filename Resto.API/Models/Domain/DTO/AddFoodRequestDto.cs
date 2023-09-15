using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resto.API.Model.Domain.DTO
{
    public class AddFoodRequestDto
    {
        [Required]
        public string FoodName { get; set; }
        [Required]
        public decimal FoodPrice { get; set; }
        public string FoodDescription { get; set; }

    }
}
