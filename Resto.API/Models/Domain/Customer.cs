using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resto.API.Model.Domain
{
    public class Customer
    {
     
        public Guid Id { get; set; }
        public string Name { get; set; }

    }
}