using Microsoft.EntityFrameworkCore;
using Resto.API.Data;
using Resto.API.Model.Domain;

namespace Resto.API.Repositories
{
    public class SQLFoodRepository : IFoodRepository
    {
        private readonly RestoDbContext dbContext;

        public SQLFoodRepository(RestoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Food> CreateAsync(Food food)
        {
            await dbContext.Foods.AddAsync(food);
            await dbContext.SaveChangesAsync();
            return food;
        }

        public async Task<List<Food>> GetAllAsync()
        {
            return await dbContext.Foods.ToListAsync();
        }

       

        public async Task<Food?> GetByIdAsync(Guid id)
        {
            return await dbContext.Foods.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
