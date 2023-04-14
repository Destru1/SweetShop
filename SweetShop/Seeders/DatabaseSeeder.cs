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
                 new Allergen{ Name = "Мляко и млечни продукти",Description="Включително и лактоза",CreatedOn = DateTime.UtcNow},
                 new Allergen{ Name = "Яйца ",Description="Включва и продукти от яйца",CreatedOn = DateTime.UtcNow},
                 new Allergen{ Name = "Зърнени култури",Description="Съдържащи глутен",CreatedOn = DateTime.UtcNow},
                 new Allergen{ Name = "Соя и соеви продукти",Description="Соя и соеви продукти",CreatedOn = DateTime.UtcNow},
                 new Allergen{ Name = "Ядки",Description="Бадем, лешник, орехи и др.",CreatedOn = DateTime.UtcNow},
            };

            if (await dbContext.Products.AnyAsync())
            {
                return;
            }

            var products = new List<Product>()
            {
                new Product
                {

                    Name = "Червено кадифе",
                    Description = "Блатове с какао и кафе, обвити в нежна комбинация от крема сирене, сметана и ванилия.",
                    ImageURL = "https://cdncloudcart.com/17396/products/images/1532/cerveno-kadife-image_5efb8be4ae54d_800x800.png?1593543702",
                    Price = 55.45m,
                    TimesSold = 5,
                    Rating = 13,
                    TimesRated = 2,
                    CreatedOn= DateTime.UtcNow,

                }, new Product
                {

                    Name = "Медена Торта",
                    Description = "Лека комбинация от йогурт, мус, медени платки и хрупкави орехи.",
                    ImageURL = "https://cdncloudcart.com/17396/products/images/1524/meden-jogurt-image_5efb8bcfdd2e8_800x800.jpeg?1593543660",
                    Price = 63.99m,
                    TimesSold = 5,
                    Rating = 0,
                    TimesRated = 0,
                    CreatedOn= DateTime.UtcNow,
                }, new Product
                {

                    Name = "Еклерова торта",
                    Description = "Торта със сърцевина от орехови платки/без варианта за 8 парчета/, пухкави еклери с млечен крем, шоколадова сметана и покрита с течен шоколад.",
                    ImageURL = "https://cdncloudcart.com/17396/products/images/1528/eklerova-sokolad-image_5efb8bd9049c7_800x800.png?1593543685",
                    Price = 49.99m,
                    TimesSold = 3,
                    Rating = 3,
                    TimesRated = 1,
                    CreatedOn= DateTime.UtcNow,
                }, new Product
                {

                    Name = "Френски макарони 12бр",
                    Description = "Цветни и вкусни оригинални макарони, луксозно опаковани.",
                    ImageURL = "https://cdncloudcart.com/17396/products/images/1494/frenski-makaroni-12br-image_5efb8b22003e4_1920x1920.jpeg?1593543489",
                    Price = 19.80m,
                    TimesSold = 5,
                    Rating = 10,
                    TimesRated = 1,
                    CreatedOn= DateTime.UtcNow,
                }, new Product
                {

                    Name = "Чийзкейк с боровинка и лимон",
                    Description = "Плътнаrа основа от кашу и бадеми се комбинира с наситения вкус на цели боровинки и лимон, а сиропите or кокос и агаве правят вкуса още по–неустоим.",
                    ImageURL = "https://ameliesweetshop.com/wp-content/uploads/2017/08/Blueberry-Lemon-Swirl-Vegan-Cheesecake-.jpg",
                    Price = 119.90m,
                    TimesSold = 1,
                    Rating = 0,
                    TimesRated = 0,
                    CreatedOn= DateTime.UtcNow,
                }, new Product
                {

                    Name = "Ягодова торта",
                    Description = "Вкусна комбинация от шоколадови блатове, сметана, млечен крем, свежи ягоди и много шоколад.",
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
             new Distributor {  Name = "Иван Солаков", City = "Варна", Address = "ул. \"България\" 16", PhoneNumber = "+359876972542", UserId = "2", CreatedOn = DateTime.UtcNow },
             new Distributor { Name = "Камелия Илиева", City = "София", Address = "ул. \"Вита\" 6", PhoneNumber = "+359884454546", UserId = "2", CreatedOn = DateTime.UtcNow },
             new Distributor { Name = "Ангел Цветков", City = "Пловдив", Address = "ул. \"Никола Козлев\" 6", PhoneNumber = "+359876972542", UserId = "2", CreatedOn = DateTime.UtcNow },
             new Distributor { Name = "Яна Димитрова", City = "В. Търново", Address = "ул. \"Марно Поле\" 23", PhoneNumber = "+359876972542", UserId = "2", CreatedOn = DateTime.UtcNow },

            };

            if (await dbContext.Clients.AnyAsync())
            {
                return;
            }

            var clients = new List<Client>()
            {
                new Client {FirstName = "Георги",
                    LastName="Иванов",
                    City="Велико Търново",
                    Address ="ул. \"Полтава\" 3",
                    PhoneNumber ="+359878888888",
                    PersonEntity=PersonEntity.Частно,
                    Distributor=distributors[3],
                    UserId="3",
                    CreatedOn = DateTime.UtcNow},

                new Client {FirstName = "Петя",
                    LastName="Тодорова",
                    City="София",
                    Address ="ул. \"Димитър Моллов",
                    PhoneNumber ="+359884375662",
                    PersonEntity=PersonEntity.Частно,
                   Distributor=distributors[1],
                    UserId="3",
                    CreatedOn = DateTime.UtcNow},

                new Client {FirstName = "Лене EOOD",
                    LastName="EOOD",
                    City="Варна",
                    Address ="ул. \"Елица\" 4",
                    PhoneNumber ="+359876315465",
                    PersonEntity= PersonEntity.Юридическо,
                    Distributor=distributors[0],
                    UserId="3",
                    CreatedOn = DateTime.UtcNow},

                new Client {
                    FirstName = "Арина",
                    LastName="Димова",
                    City="Пловдив",
                    Address ="ул. \"Младежка\" 17",
                    PhoneNumber ="+359887933345",
                    PersonEntity=PersonEntity.Частно,
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
                new Order{OrderedOn= new DateTime(2023,04,02),
                Quantity=3,
                Client=clients[2],
                Product=products[0],
                CreatedOn= DateTime.UtcNow},

                new Order{OrderedOn= new DateTime(2023,04,02),
                Quantity=5,
                Client=clients[3],
                Product=products[3],
                CreatedOn= DateTime.UtcNow},

                new Order{OrderedOn= new DateTime(2023,04,06),
                Quantity=1,
                Client=clients[0],
                Product=products[5],
                CreatedOn= DateTime.UtcNow},

                new Order{OrderedOn= new DateTime(2023,04,07),
                Quantity=1,
                Client=clients[0],
                Product=products[1],
                CreatedOn= DateTime.UtcNow},

                new Order{OrderedOn= new DateTime(2023,04,03),
                Quantity=2,
                Client=clients[1],
                Product=products[2],
                CreatedOn= DateTime.UtcNow},

                new Order{OrderedOn= new DateTime(2023,04,08),
                Quantity=4,
                Client=clients[2],
                Product=products[1],
                CreatedOn= DateTime.UtcNow},

                new Order{OrderedOn= new DateTime(2023,04,11),
                Quantity=1,
               Client=clients[3],
                Product=products[4],
                CreatedOn= DateTime.UtcNow},

                new Order{OrderedOn= new DateTime(2023,04,05),
                Quantity=1,
                Client=clients[2],
                Product=products[2],
                CreatedOn= DateTime.UtcNow},

                new Order{OrderedOn= new DateTime(2023,04,01),
                Quantity=1,
                Client=clients[1],
                Product=products[5],
                CreatedOn= DateTime.UtcNow},

                new Order{
                OrderedOn= new DateTime(2023,04,04),
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
                Description="Ако сте любител на сладкото, определено бих препоръчала да опитате френските макарони и да се насладите на тяхната изискана вкусова комбинация.",
                Rating=10,
                CreatedOn= DateTime.UtcNow,},

                new Review{
                Client=clients[0],
                Product=products[0],
                Description="Направо ще кажа, че тортата беше изключително вкусна и възхитителна. Приятно изненадана бях от мекотата на тестото и свежестта на крема. Декорацията беше изработена майсторски и беше удоволствие да я гледам.\r\n\r\nС увереност мога да кажа, че тази торта е една от най-добрите, които съм опитал в последно време.",
                Rating=9,
                CreatedOn= DateTime.UtcNow,},

                new Review{
                Client=clients[1],
                Product=products[5],
                Description="Като изкушен сладкохапващ човек, аз мога да кажа, че тази торта е просто вълшебна! Текстурата й е мека и въздушна, а вкусът е перфектно балансиран между сладост и пикантност. Направо може да се усети, че са използвани само най-качествени продукти при приготвянето й.",
                Rating=7,
                CreatedOn= DateTime.UtcNow,},

                new Review{
                Client=clients[2],
                Product=products[2],
                Description="За съжаление, тази торта беше много разочароваща. Текстурата й беше тежка и неприятна на вкус, като че ли е била изпечена прекалено дълго време. Вкусът й беше изкуствен и безличен, а нито един от съставките не можеше да се усети.",
                Rating=3,
                CreatedOn= DateTime.UtcNow,},

                new Review{
                Client=clients[3],
                Product=products[0],
                Description="Съжалявам, но трябва да напиша отзив за тази торта, който не е толкова положителен. Може би е просто нещастна случайност, но тортата, която получих, беше малко изсъхнала и без вкус. Текстурата й беше твърда и не особено приятна за ядене.",
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
