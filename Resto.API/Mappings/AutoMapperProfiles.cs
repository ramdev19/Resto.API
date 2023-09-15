using AutoMapper;
using Resto.API.Model.Domain;
using Resto.API.Model.Domain.DTO;
using Resto.API.Models.Domain.DTO;

namespace Resto.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<Food, FoodDto>().ReverseMap();
            CreateMap<AddFoodRequestDto, Food>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderDetails, OrderDetailDto>().ReverseMap();
            CreateMap<Transaction, TransactionDto>().ReverseMap();



        }
       
    }
}
