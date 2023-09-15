using Resto.API.Model.Domain;

namespace Resto.API.Repositories
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllAsync();
    }
}
