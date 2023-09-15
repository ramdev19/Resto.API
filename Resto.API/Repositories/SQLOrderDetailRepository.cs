using Microsoft.EntityFrameworkCore;
using Resto.API.Data;
using Resto.API.Model.Domain;

namespace Resto.API.Repositories
{
    public class SQLOrderDetailRepository : IOrderDetailRepository
    {

        private readonly RestoDbContext dbContext;
        public SQLOrderDetailRepository(RestoDbContext dbContext)
        {
                this.dbContext = dbContext;
        }
        public async Task<List<OrderDetails>> GetAllAsync()
        {
            return await dbContext.OrderDetails.Include("Order").Include("Food").ToListAsync();

        }
    }
}
