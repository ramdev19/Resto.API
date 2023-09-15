using Resto.API.Model.Domain;

namespace Resto.API.Repositories
{
    public interface IOrderDetailRepository
    {
        Task<List<OrderDetails>> GetAllAsync();
    }
}
