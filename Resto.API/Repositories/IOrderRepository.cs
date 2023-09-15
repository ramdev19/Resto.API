using Resto.API.Model.Domain;

namespace Resto.API.Repositories
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllAsync();
    }
}
