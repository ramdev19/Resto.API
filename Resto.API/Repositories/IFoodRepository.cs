using Resto.API.Model.Domain;

namespace Resto.API.Repositories
{
    public interface IFoodRepository
    {
        Task<List<Food>> GetAllAsync();
        Task<Food?> GetByIdAsync(Guid id);
        Task<Food> CreateAsync(Food food);

       
    }
}
