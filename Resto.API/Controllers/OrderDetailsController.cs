using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Resto.API.Data;
using Resto.API.Model.Domain;
using Resto.API.Models.Domain;
using Resto.API.Models.Domain.DTO;
using Resto.API.Repositories;

namespace Resto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : Controller
    {
        private readonly RestoDbContext dbContext;
        private IOrderDetailRepository orderDetailRepository;
        private readonly IMapper mapper;

        public OrderDetailsController(RestoDbContext dbContext, IOrderDetailRepository orderDetailRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.orderDetailRepository = orderDetailRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var detail = await orderDetailRepository.GetAllAsync();
            return Ok(mapper.Map<List<OrderDetailDto>>(detail));
        }




        [HttpPost("SaveDataOrdered")]
        public async Task<ActionResult<List<OrderDetails>>> SaveDataOrdered([FromForm] string jsonData)
        {
            try
            {
                var result = JsonConvert.DeserializeObject<Orders>(jsonData);
                if (result != null)
                {
                    Order newOrder = new Order()
                    {
                        // CustomerId = result.CustomerId,
                        CustomerId = Guid.Parse("6E1305B1-56AE-4E2B-8ED0-6783983B0901"),
                        OrderDate = result.OrderDate,
                        TotalPayment = result.TotalPayment,
                    };
                    dbContext.Add(newOrder);
                    await dbContext.SaveChangesAsync();

                    // for details 
                    var idOrder = await dbContext.Orders.OrderByDescending(x => x.OrderId).FirstOrDefaultAsync();
                    int idOrders = idOrder == null ? 0 : idOrder.OrderId;


                    // var originalGuid = Guid.NewGuid();

                    for (var i = 0; i < result.OrderDetails.Count; i++)
                    {
                        result.OrderDetails[i].OrderId = idOrders;
                    }
                    dbContext.AddRange(result.OrderDetails);
                    await dbContext.SaveChangesAsync();

                    //payment 
                    Transaction trans = new Transaction()
                    {
                        OrderId = idOrders,
                        TransactionDate = result.OrderDate
                    };

                    dbContext.Add(trans);
                    await dbContext.SaveChangesAsync();

                }
                return Ok(await dbContext.OrderDetails.ToListAsync());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
       
    }
}
