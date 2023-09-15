using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resto.API.Model.Domain
{
    public class Food
    {
        [Key]
        public Guid Id { get; set; }
        [Column(TypeName ="VARCHAR(100)")]
        public string FoodName { get; set; }
        [Column(TypeName ="decimal(18,4)")]
        public decimal FoodPrice { get; set; }
        [Column(TypeName = "VARCHAR(250)")]
        public string FoodDescription { get; set;}

    }
}
