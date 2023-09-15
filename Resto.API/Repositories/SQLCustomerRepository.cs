using Microsoft.EntityFrameworkCore;
using Resto.API.Data;
using Resto.API.Model.Domain;

namespace Resto.API.Repositories
{
    public class SQLCustomerRepository : ICustomerRepository
    {
        private readonly RestoDbContext dbContext;
        public SQLCustomerRepository(RestoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<Customer>> GetAllAsync()
        {
            return await dbContext.Customers.ToListAsync();
        }
    }
}
