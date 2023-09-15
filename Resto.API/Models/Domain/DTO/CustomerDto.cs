using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Resto.API.Models.Domain.DTO
{
    public class CustomerDto
    {
      
        public Guid Id { get; set; }
        public string Name { get; set; }

    }
}
