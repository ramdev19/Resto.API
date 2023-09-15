
using Microsoft.EntityFrameworkCore;
using Resto.API.Model.Domain;

namespace Resto.API.Data
{
    public class RestoDbContext : DbContext
    {
        public RestoDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Food> Foods { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        //seed for Add Food to the database 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed Add Food to the database 
            var food = new List<Food>()
            {
                new Food()
                {
                    Id = Guid.Parse("e1acf2f6-2a21-427c-a1ee-d3442664004b"),
                    FoodName = "Butter Garlic Sauce",
                    FoodDescription = "Main Men",
                    FoodPrice = 298000
                },
                new Food()
                {

                    Id = Guid.Parse("ed45ffaf-f684-4e5b-9508-d6fc930d44fc"),
                    FoodName = "Singapore Chilli Sauce",
                    FoodDescription = "Main Menu",
                    FoodPrice = 235000
                },
                new Food()
                {

                    Id= Guid.Parse("b542e7c7-8558-41e4-b516-e87cd420102c"),
                    FoodName = "Bakar Bumbu Asap",
                    FoodDescription = "Main Menu",
                    FoodPrice = 298000
                },
                new Food()
                {

                    Id= Guid.Parse("eb920cd4-dfe1-4c75-a3f8-fc6bf86a2b02"),
                    FoodName = "Tumis Tauge Kecap",
                    FoodDescription = "Vegetable",
                    FoodPrice = 235000
                },
                new Food()
                {

                    Id = Guid.Parse("cc773bcc-8eda-4228-92ec-5b09361dd9f1"),
                    FoodName = "Fried Mantau",
                    FoodDescription = "Appetizer",
                    FoodPrice =  22000
                },
                new Food()
                {
                    Id = Guid.Parse("889964ae-3c02-4b98-8695-8b45d1e5904c"),
                    FoodName ="Fried Potato",
                    FoodDescription = "Appetizer",
                    FoodPrice = 35000
                },
                new Food()
                {

                    Id = Guid.Parse("02f1a833-c09a-42a5-a459-e5aad275d806"),
                    FoodName = "Chicken Crispy",
                    FoodDescription = "Main Menu",
                    FoodPrice = 75000
                }
            };
            modelBuilder.Entity<Food>().HasData(food);

            //Seed data for Customer 
            var customers = new List<Customer>()
            {
                new Customer()
                {
                    Id =Guid.Parse("6e1305b1-56ae-4e2b-8ed0-6783983b0901"),
                    Name = "Shaka"
                }
            };
            modelBuilder.Entity<Customer>().HasData(customers);

            //Seed data Order

            var order = new List<Order>()
            {
                new Order()
                {
                    OrderId = 1,
                    CustomerId = Guid.Parse( "6e1305b1-56ae-4e2b-8ed0-6783983b0901"),
                    OrderDate = DateTime.Now,
                    TotalPayment = 298000,
                }
            };
            modelBuilder.Entity<Order>().HasData(order);
        }


    }
}
