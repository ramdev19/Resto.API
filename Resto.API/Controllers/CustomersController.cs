using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Resto.API.CustomActionFilters;
using Resto.API.Data;
using Resto.API.Model.Domain;
using Resto.API.Model.Domain.DTO;
using Resto.API.Models.Domain.DTO;
using Resto.API.Repositories;

namespace Resto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly RestoDbContext dbContext;
        private ICustomerRepository customerRepository;
        private readonly IMapper mapper;


        public CustomersController(RestoDbContext dbContext, ICustomerRepository customerRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.customerRepository = customerRepository;
            this.mapper = mapper;
        }
        // https://localhost:1234/api/customers
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //Get Data from database - domain models
            var customerDomain = await customerRepository.GetAllAsync();

            //return DTOS
            return Ok(mapper.Map<List<CustomerDto>>(customerDomain));
        }
    }
}
