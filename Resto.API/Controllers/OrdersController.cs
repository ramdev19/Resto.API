using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resto.API.Data;
using Resto.API.Models.Domain.DTO;
using Resto.API.Repositories;

namespace Resto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly RestoDbContext dbContext;
        private IOrderRepository orderRepository;
        private readonly IMapper mapper;

        public OrdersController(RestoDbContext dbContext, IOrderRepository orderRepository, IMapper mapper) 
        {
            this.dbContext = dbContext;
            this.orderRepository = orderRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task <IActionResult> GetAll()
        {
            var order = await orderRepository.GetAllAsync();

            return Ok(mapper.Map<List<OrderDto>>(order));
        }


    }
}
