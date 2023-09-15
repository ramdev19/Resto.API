using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json;
using Resto.API.CustomActionFilters;
using Resto.API.Data;
using Resto.API.Model.Domain;
using Resto.API.Model.Domain.DTO;
using Resto.API.Models.Domain.DTO;
using Resto.API.Repositories;

namespace Resto.API.Controllers
{
    // https://localhost:1234/api/foods
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : Controller
    {
        private readonly RestoDbContext dbContext;
        private IFoodRepository foodRepository;
        private readonly IMapper mapper;

        public FoodsController(RestoDbContext dbContext, IFoodRepository foodRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.foodRepository = foodRepository;
            this.mapper = mapper;
        }

        //Get All foods
        [HttpGet]
        public async Task <IActionResult> GetAll()
        {
            var foodsDomain = await foodRepository.GetAllAsync();
            return Ok(mapper.Map<List<FoodDto>>(foodsDomain));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var foodDomain = await foodRepository.GetByIdAsync(id);

            if (foodDomain == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<FoodDto>(foodDomain));
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddFoodRequestDto addFoodRequestDto)
        {
            var foodDomainModel = mapper.Map<Food>(addFoodRequestDto);

            foodDomainModel = await foodRepository.CreateAsync(foodDomainModel);

            var foodDto = mapper.Map<FoodDto>(foodDomainModel);
            return CreatedAtAction(nameof(GetById), new {id = foodDto.Id}, foodDto);

        }
       
    }
}