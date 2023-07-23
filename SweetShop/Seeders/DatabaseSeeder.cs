using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SweetShop.Data;
using SweetShop.Models;
using SweetShop.Models.Enums;
using SweetShop.Seeder;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SweetShop.Seeders
{
    public class DatabaseSeeder : ISeeder
    {
        public async Task SeedAsync(IServiceScope serviceScope)
        {
            var dbContext = serviceScope.ServiceProvider.GetRequiredService<SweetShopDbContext>();

            if (await dbContext.Allergens.AnyAsync())
            {
                return;
            }

            var allergens = new List<Allergen>()
            {
                 new Allergen{ Name = "Milk",Description="Including lactose.",CreatedOn = DateTime.UtcNow},
                 new Allergen{ Name = "Eggs ",Description="Products with eggs",CreatedOn = DateTime.UtcNow},
                 new Allergen{ Name = "Cereals",Description="Containing gluten",CreatedOn = DateTime.UtcNow},
                 new Allergen{ Name = "Soybeans",Description="Products containig soybeans",CreatedOn = DateTime.UtcNow},
                 new Allergen{ Name = "Nuts",Description="Almonds, hazelnuts, walnuts etc.",CreatedOn = DateTime.UtcNow},
            };

            if (await dbContext.Products.AnyAsync())
            {
                return;
            }

            var products = new List<Product>()
            {
                new Product
                {

                    Name = "Red velvet",
                    Description = "Cocoa and coffee marshmallows wrapped in a delicate combination of cream cheese, cream and vanilla.",
                    ImageURL = "https://cdncloudcart.com/17396/products/images/1532/cerveno-kadife-image_5efb8be4ae54d_800x800.png?1593543702",
                    Price = 55.45m,
                    TimesSold = 5,
                    Rating = 13,
                    TimesRated = 2,
                    CreatedOn= DateTime.UtcNow,

                }, new Product
                {

                    Name = "Honey Cake",
                    Description = "A light combination of yogurt, mousse, honey wafers and crunchy walnuts.",
                    ImageURL = "https://cdncloudcart.com/17396/products/images/1524/meden-jogurt-image_5efb8bcfdd2e8_800x800.jpeg?1593543660",
                    Price = 63.99m,
                    TimesSold = 5,
                    Rating = 0,
                    TimesRated = 0,
                    CreatedOn= DateTime.UtcNow,
                }, new Product
                {

                    Name = "Eclair cake",
                    Description = "Cake with a core of walnut wafers/without the option for 8 pieces/, fluffy eclairs with milk cream, chocolate cream and covered with liquid chocolate.",
                    ImageURL = "https://cdncloudcart.com/17396/products/images/1528/eklerova-sokolad-image_5efb8bd9049c7_800x800.png?1593543685",
                    Price = 49.99m,
                    TimesSold = 3,
                    Rating = 3,
                    TimesRated = 1,
                    CreatedOn= DateTime.UtcNow,
                }, new Product
                {

                    Name = "French macarons 12 pcs",
                    Description = "Colorful and delicious original macarons, luxuriously packaged.",
                    ImageURL = "https://cdncloudcart.com/17396/products/images/1494/frenski-makaroni-12br-image_5efb8b22003e4_1920x1920.jpeg?1593543489",
                    Price = 19.80m,
                    TimesSold = 5,
                    Rating = 10,
                    TimesRated = 1,
                    CreatedOn= DateTime.UtcNow,
                }, new Product
                {

                    Name = "Cheesecake with blueberry and lemon",
                    Description = "The dense base of cashews and almonds is combined with the rich taste of whole blueberries and lemon, and the coconut and agave syrups make the taste even more irresistible.",
                    ImageURL = "https://ameliesweetshop.com/wp-content/uploads/2017/08/Blueberry-Lemon-Swirl-Vegan-Cheesecake-.jpg",
                    Price = 119.90m,
                    TimesSold = 1,
                    Rating = 0,
                    TimesRated = 0,
                    CreatedOn= DateTime.UtcNow,
                }, new Product
                {

                    Name = "Strawberry cake",
                    Description = "A delicious combination of chocolate marshmallows, cream, milk cream, fresh strawberries and lots of chocolate.\r\n",
                    ImageURL = "https://cdncloudcart.com/17396/products/images/1522/agodova-image_6157f5da78bd4_600x600.png?1633154554",
                    Price = 49.99m,
                    TimesSold = 2,
                    Rating = 7,
                    TimesRated = 1,
                    CreatedOn= DateTime.UtcNow,
                },
            };

            if (await dbContext.ProductAllergens.AnyAsync())
            {
                return;
            }


            var productAllergens = new List<ProductAllergen>()
            {
                new ProductAllergen { Product = products[0],Allergen=allergens[0], CreatedOn= DateTime.UtcNow},
                new ProductAllergen { Product = products[0],Allergen=allergens[1], CreatedOn= DateTime.UtcNow},
                new ProductAllergen { Product = products[0],Allergen=allergens[2], CreatedOn= DateTime.UtcNow},
                new ProductAllergen { Product = products[1],Allergen=allergens[0], CreatedOn= DateTime.UtcNow},
                new ProductAllergen { Product = products[1],Allergen=allergens[1], CreatedOn= DateTime.UtcNow},
                new ProductAllergen { Product = products[1],Allergen=allergens[2], CreatedOn= DateTime.UtcNow},
                new ProductAllergen { Product = products[1],Allergen=allergens[4], CreatedOn= DateTime.UtcNow},
                new ProductAllergen { Product = products[2],Allergen=allergens[0], CreatedOn= DateTime.UtcNow},
                new ProductAllergen { Product = products[2],Allergen=allergens[1], CreatedOn= DateTime.UtcNow},
                new ProductAllergen { Product = products[2],Allergen=allergens[2], CreatedOn= DateTime.UtcNow},
                new ProductAllergen { Product = products[2],Allergen=allergens[3], CreatedOn= DateTime.UtcNow},
                new ProductAllergen { Product = products[2],Allergen=allergens[4], CreatedOn= DateTime.UtcNow},
                new ProductAllergen { Product = products[3],Allergen=allergens[0], CreatedOn= DateTime.UtcNow},
                new ProductAllergen { Product = products[3],Allergen=allergens[1], CreatedOn= DateTime.UtcNow},
                new ProductAllergen { Product = products[3],Allergen=allergens[3], CreatedOn= DateTime.UtcNow},
                new ProductAllergen { Product = products[4],Allergen=allergens[4], CreatedOn= DateTime.UtcNow},
                new ProductAllergen { Product = products[4],Allergen=allergens[3], CreatedOn= DateTime.UtcNow},
                new ProductAllergen { Product = products[5],Allergen=allergens[1], CreatedOn= DateTime.UtcNow},
                new ProductAllergen { Product = products[5],Allergen=allergens[2], CreatedOn= DateTime.UtcNow},
                new ProductAllergen { Product = products[5],Allergen=allergens[3], CreatedOn= DateTime.UtcNow},

            };


            if (await dbContext.Distributors.AnyAsync())
            {
                return;
            }

            var distributors = new List<Distributor>()
            {
             new Distributor {  Name = "Ivan Solakov", City = "Varna", Address = " \"Bulgaria\" 16", PhoneNumber = "+359876972542", UserId = "2", CreatedOn = DateTime.UtcNow },
             new Distributor { Name = "Kamelia Ilieva", City = "Sofia", Address = " \"Vita\" 6", PhoneNumber = "+359884454546", UserId = "2", CreatedOn = DateTime.UtcNow },
             new Distributor { Name = "Angel Cvetkov", City = "Plovdiv", Address = " \"Nikola Kozlev\" 6", PhoneNumber = "+359876972542", UserId = "2", CreatedOn = DateTime.UtcNow },
             new Distributor { Name = "Yana Dimitrova", City = "V. Turnovo", Address = " \"Marno pole\" 23", PhoneNumber = "+359876972542", UserId = "2", CreatedOn = DateTime.UtcNow },

            };

            if (await dbContext.Clients.AnyAsync())
            {
                return;
            }

            var clients = new List<Client>()
            {
                new Client {FirstName = "Georgi",
                    LastName="Ivanov",
                    City="V. Turnovo",
                    Address ="\"Poltava\" 3",
                    PhoneNumber ="+359878888888",
                    PersonEntity=PersonEntity.Private,
                    Distributor=distributors[3],
                    UserId="3",
                    CreatedOn = DateTime.UtcNow},

                new Client {FirstName = "Petya",
                    LastName="Todorova",
                    City="Sofia",
                    Address ="\"Dimitar Molov 2",
                    PhoneNumber ="+359884375662",
                    PersonEntity=PersonEntity.Private,
                   Distributor=distributors[1],
                    UserId="3",
                    CreatedOn = DateTime.UtcNow},

                new Client {FirstName = "Holding",
                    LastName="EOOD",
                    City="Varna",
                    Address ="\"Elitsa\" 4",
                    PhoneNumber ="+359876315465",
                    PersonEntity= PersonEntity.Legal,
                    Distributor=distributors[0],
                    UserId="3",
                    CreatedOn = DateTime.UtcNow},

                new Client {
                    FirstName = "Arina",
                    LastName="Dimova",
                    City="Plovdiv",
                    Address =" \"Младежка\" 17",
                    PhoneNumber ="+359887933345",
                    PersonEntity=PersonEntity.Private,
                    Distributor=distributors[2],
                    UserId="3",
                    CreatedOn = DateTime.UtcNow},

            };


            if (await dbContext.Orders.AnyAsync())
            {
                return;
            }

            var orders = new List<Order>()
            {
                new Order{OrderedOn= DateTime.UtcNow.AddDays(-2),
                Quantity=3,
                Client=clients[2],
                Product=products[0],
                CreatedOn= DateTime.UtcNow},

                new Order{OrderedOn= DateTime.UtcNow.AddDays(+1),
                Quantity=5,
                Client=clients[3],
                Product=products[3],
                CreatedOn= DateTime.UtcNow},

                new Order{OrderedOn=DateTime.UtcNow.AddDays(+2),
                Quantity=1,
                Client=clients[0],
                Product=products[5],
                CreatedOn= DateTime.UtcNow},

                new Order{OrderedOn= DateTime.UtcNow,
                Quantity=1,
                Client=clients[0],
                Product=products[1],
                CreatedOn= DateTime.UtcNow},

                new Order{OrderedOn= DateTime.UtcNow,
                Quantity=2,
                Client=clients[1],
                Product=products[2],
                CreatedOn= DateTime.UtcNow},

                new Order{OrderedOn= DateTime.UtcNow.AddDays(-1),
                Quantity=4,
                Client=clients[2],
                Product=products[1],
                CreatedOn= DateTime.UtcNow},

                new Order{OrderedOn= DateTime.UtcNow.AddDays(-1),
                Quantity=1,
               Client=clients[3],
                Product=products[4],
                CreatedOn= DateTime.UtcNow},

                new Order{OrderedOn= DateTime.UtcNow.AddDays(-2),
                Quantity=1,
                Client=clients[2],
                Product=products[2],
                CreatedOn= DateTime.UtcNow},

                new Order{OrderedOn=DateTime.UtcNow.AddDays(+1),
                Quantity=1,
                Client=clients[1],
                Product=products[5],
                CreatedOn= DateTime.UtcNow},

                new Order{
                OrderedOn= DateTime.UtcNow,
                Quantity=2,
                Client=clients[0],
                Product=products[0],
                CreatedOn= DateTime.UtcNow},

            };


            if (await dbContext.Reviews.AnyAsync())
            {
                return;
            }


            var reviews = new List<Review>()
            {
                new Review{
                Client=clients[3],
                Product=products[3],
                Description="If you have a sweet tooth, I would definitely recommend trying the French macarons and enjoying their exquisite flavor combination.",
                Rating=10,
                CreatedOn= DateTime.UtcNow,},

                new Review{
                Client=clients[0],
                Product=products[0],
                Description="\r\nI will say straight away that the cake was extremely tasty and delightful. I was pleasantly surprised by the softness of the dough and the freshness of the cream. The decoration was masterfully done and a joy to look at.I can confidently say that this cake is one of the best I have tried in recent times.",
                Rating=9,
                CreatedOn= DateTime.UtcNow,},

                new Review{
                Client=clients[1],
                Product=products[5],
                Description="As a sophisticated sweet tooth, I can say that this cake is simply magical! Its texture is soft and airy, and the taste is perfectly balanced between sweetness and spiciness. You can directly feel that only the best quality products were used in its preparation.",
                Rating=7,
                CreatedOn= DateTime.UtcNow,},

                new Review{
                Client=clients[2],
                Product=products[2],
                Description="Unfortunately, this cake was very disappointing. Its texture was heavy and it tasted unpleasant, as if it had been baked for too long. It tasted artificial and impersonal, and none of the ingredients could be felt.",
                Rating=3,
                CreatedOn= DateTime.UtcNow,},

                new Review{
                Client=clients[3],
                Product=products[0],
                Description="Sorry, but I have to write a review for this cake that is not so positive. Maybe it's just a fluke, but the cake I received was a bit dry and tasteless. Its texture was hard and not very pleasant to eat.",
                Rating=4,
                CreatedOn= DateTime.UtcNow,},
            };

            await dbContext.Allergens.AddRangeAsync(allergens);
            await dbContext.Products.AddRangeAsync(products);
            await dbContext.ProductAllergens.AddRangeAsync(productAllergens);
            await dbContext.Distributors.AddRangeAsync(distributors);
            await dbContext.Clients.AddRangeAsync(clients);
            await dbContext.Orders.AddRangeAsync(orders);
            await dbContext.Reviews.AddRangeAsync(reviews);

            await dbContext.SaveChangesAsync();
        }
    }
}
