using Microsoft.EntityFrameworkCore;
using Resto.API.Data;
using Resto.API.Model.Domain;

namespace Resto.API.Repositories
{
    public class SQLOrderRepository : IOrderRepository
    {
    
        private readonly RestoDbContext dbContext;

        public SQLOrderRepository(RestoDbContext dbContext)
        {
           
            this.dbContext = dbContext;
        }
        public async Task<List<Order>> GetAllAsync()
        {
            return await dbContext.Orders.Include("Customer").ToListAsync();
        }
    }
}
