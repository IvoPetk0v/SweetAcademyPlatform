using SweetAcademy.Data;

using SweetAcademy.Data.Models;

namespace SweetAcademy.Services.Tests
{
    public class DatabaseSeeder
    {
        public static ApplicationUser ChefUser;
        public static ApplicationUser CustomerUser;
        public static List<Product> Products;
        public static List<Recipe> Recipes;
        public static List<RecipeProduct> RecipeProducts;
        public static Chef Chef;
        public static List<Training> Training;
    
        public static void SeedDatabase(SweetAcademyDbContext dbContext)
        {
            ChefUser = new ApplicationUser()
            {
                Id = Guid.Parse("5BFC2446-3FD2-4990-9265-08DB8AAD116C"),
                UserName = "admin@admin.bg",
                NormalizedEmail = "ADMIN@ADMIN.BG",
                PasswordHash = "AQAAAAEAACcQAAAAEHXuw6dYlxC8AEJ5dq817hzjCU/O72xLYs+NeKUXL/Rdikx4mt6Q3+3jzAhARG4NEA==",
                SecurityStamp = "EF2DAKHPWV6KTXCJF4JR2RQMHEXPPGQ3",
                ConcurrencyStamp = "df94bcd6-62ee-46f1-a089-0576b12308bf",
                LockoutEnabled = true,
            };

            CustomerUser = new ApplicationUser()
            {
                Id = Guid.Parse("21D6DFFE-E209-4DCC-9FA9-08DB92B169A9"),
                UserName = "ip@customer.bg",
                NormalizedEmail = "IP@CUSTOMER.BG",
                PasswordHash = "AQAAAAEAACcQAAAAEO1XTr6PzJ1+1+fdYOEB+Dq8GcV5kClGxOY90gYEs0MmzeRZA2G7eGL205oEaCYbcg==",
                SecurityStamp = "2WCQ3I2BZ2DU4YJT62ZMCHKVUCO2PKGL",
                ConcurrencyStamp = "f420ec05-4560-49a1-a22a-3a7c6b0ffc9a",
                LockoutEnabled = true,
            };

            Products = new List<Product>()
            {
                new Product
                {
                    Id = 1,
                    Name = "Sugar",
                    Price = 0.20m,
                    Unit = "50 g."
                },
                new Product
                {
                    Id = 2,
                    Name = "Butter",
                    Price = 6.99m,
                    Unit = "250 g."
                },
                new Product
                {
                    Id = 3,
                    Name = "Chocolate",
                    Price = 3.50m,
                    Unit = "90 g."
                },
                new Product()
                {
                    Id = 4,
                    Name = "Milk",
                    Price = 1.5m,
                    Unit = "500 ml"
                }
            };

            Recipes = new List<Recipe>()
            {
                new Recipe()
            {
                Id = 1,
                Description = "Bake an impressive dinner party dessert with minimum fuss – these chocolate puddings, also known as chocolate fondant or lava cake, have a lovely gooey center",
                ImageUrl = "https://img.freepik.com/free-vector/chocolate-lava-cake-with-raspberry-sticker-isolated-white-background_1308-65607.jpg?w=740&t=st=1690710465~exp=1690711065~hmac=c96a6d3712a020c5968f3facf16b2b30de62319e54a40295bdf134c02fef733a",
                Name = "Lava Cake",
                Active = true,

                StepsJson = "[\"Heat oven to 200C/180C fan/gas 6. Butter 6 dariole moulds or basins well and place on a baking tray.\",\"Carefully run a knife around the edge of each pudding, then turn out onto serving plates and serve with single cream.\"]"
            },
            new Recipe()
            {
                Id = 2,
                Description = "Dairy-free and egg-free, this delicious ice cream is surprisingly rich and indulgent. Use whatever add-ins you like in this dairy-free ice cream; a fantastic base recipe that's super easy!",
                ImageUrl = "https://img.freepik.com/free-vector/ice-cream-cone-cartoon-icon-illustration-sweet-food-icon-concept-isolated-flat-cartoon-style_138676-2924.jpg?w=740&t=st=1690915084~exp=1690915684~hmac=541a6d2f00afd0f44bf7033fbbb68151944f853d57559807362364812e0bef60",
                Name = "VEGAN ICE CREAM",
                Active = true,

                StepsJson = "[\"Blend: In a blender, add all ingredients and blend on high until thick and creamy, 1-2 min. Transfer mixture to an airtight container and chill 2-4 hours.\",\"Freeze: May serve immediately for a frozen custard-like texture that's ultra creamy, smooth, and soft. Otherwise, transfer ice cream to an airtight container and freeze 30-60 minutes for a firmer texture. If frozen much longer, it will need thaw time at room temp before serving (actual thaw time depends on your room temp.)\"]",
            }

            };

            RecipeProducts = new List<RecipeProduct>()
            {
                new RecipeProduct()
                {
                    ProductId = 1,
                    RecipeId = 1,
                    Quantity = 5

                },
                new RecipeProduct()
                {
                    ProductId = 2,
                    RecipeId = 1,
                    Quantity = 1
                },
                new RecipeProduct()
                {
                    ProductId = 3,
                    RecipeId = 1,
                    Quantity = 4
                },
                new RecipeProduct()
                {
                    ProductId = 1,
                    RecipeId = 2,
                    Quantity = 5
                },
                new RecipeProduct()
                {
                    ProductId = 2,
                    RecipeId = 2
                },
                new RecipeProduct()
                {
                    ProductId = 3,
                    RecipeId = 2,
                    Quantity = 4
                }
            };

            Chef = new Chef()
            {
                Id = Guid.Parse("E7ECBFE6-BE8C-4C46-AE6F-001BBD8A4182"),
                Active = true,
                ApplicationUserId = Guid.Parse("5BFC2446-3FD2-4990-9265-08DB8AAD116C"),
                FullName = "Steffy Cheffy",
                PhoneNumber = 899999999,
                TaxPerTrainingForStudent = 30.50m
            };

            Training = new List<Training>()
            {
                new Training()
                {
                    Id = 1,
                    Name = "Learn how to make Lava Cake like a pro with Stef",
                    OpenSeats = 1,
                    RecipeId = 1,
                    StartDate = DateTime.Parse("12/2/2024 20:30"),
                    Active = true,
                    ChefId = Guid.Parse("E7ECBFE6-BE8C-4C46-AE6F-001BBD8A4182"),

                },
                new Training()
                {
                    Id = 2,
                    Name = "Learn how to make Lava Cake vol.2",
                    OpenSeats = 2,
                    RecipeId = 1,
                    StartDate = DateTime.Parse("12/2/2023 20:30"),
                    Active = true,
                    ChefId = Guid.Parse("E7ECBFE6-BE8C-4C46-AE6F-001BBD8A4182"),

                },
            };
            
            dbContext.ApplicationUsers.AddRange(ChefUser, CustomerUser);
            dbContext.Products.AddRange(Products);
            dbContext.Recipes.AddRange(Recipes);
            dbContext.RecipesProducts.AddRange(RecipeProducts);
            dbContext.Chefs.Add(Chef);
            dbContext.Trainings.AddRange(Training);
        
        }

    }
}
