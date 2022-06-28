using Example.Data;
using Microsoft.EntityFrameworkCore;
using PlantsShop.Models;

namespace PlantsShop.Data
{
    public class SeedData
    {
        public static void AddData(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            if (context.Products.Any())
            {
                return;
            }

            
            var companies = new Company[]
            {
                new Company
                {
                    Name="London Pot",
                },
                new Company
                {
                    Name="Green Park"
                },
                new Company
                {
                    Name="Tree House"
                },
                new Company
                {
                    Name="Kelowna Furniture"
                }
            };
            if (!context.Companies.Any())
            {
                foreach (var company in companies)
                {
                    context.Companies.Add(company);
                }
                context.SaveChanges();
            }

            var types = new Specie[]
            {
                new Specie
                {
                    Name="Banyan"
                },
                new Specie
                {
                    Name="Alocasia"
                }, new Specie
                {
                    Name="Peperomia"
                }, new Specie
                {
                    Name="Succulents"
                }
            };
            if (!context.Species.Any())
            {
                foreach (var type in types)
                {
                    context.Species.Add(type);
                }
                context.SaveChanges();
            }
            var plants = new Product[]
            {
                new Product
                {
                    Name="Opuntia Microdaysys",
                    Price=125,
                    Quantity=100,
                    ActualCost=100,
                    Description="Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim laborum.",
                    ImgTitle="Opuntia_Microdaysys",
                    Rating=Rate.Five,
                    SpecieId=types.Single(i => i.Name=="Succulents").Id,
                    CompanyId=companies.Single(i => i.Name=="Tree House").Id
                },
                new Product
                {
                    Name="Cactus Flat",
                    Price=160,
                    Quantity=30,
                    ActualCost=95,
                    Description="Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim laborum.",
                    ImgTitle="Cactus_Flat",
                    Rating=Rate.Five,
                    SpecieId=types.Single(i => i.Name=="Succulents").Id,
                    CompanyId=companies.Single(i => i.Name=="London Pot").Id
                },new Product
                {
                    Name="Acheveria Agave",
                    Price=55,
                    Quantity=10,
                    ActualCost=40,
                    Description="Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim laborum.",
                    ImgTitle="Acheveria_Agave",
                    Rating=Rate.Two,
                    SpecieId=types.Single(i => i.Name=="Succulents").Id,
                    CompanyId=companies.Single(i => i.Name=="London Pot").Id
                },new Product
                {
                    Name="Cylindrical Snake",
                    Price=175,
                    Quantity=10,
                    ActualCost=110,
                    Description="Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim laborum.",
                    ImgTitle="Cylindrical_Snake",
                    Rating=Rate.Three,
                    SpecieId=types.Single(i => i.Name=="Succulents").Id,
                    CompanyId=companies.Single(i => i.Name=="London Pot").Id
                },new Product
                {
                    Name="Aglaonema Silver",
                    Price=150,
                    Quantity=12,
                    ActualCost=100,
                    Description="Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    ImgTitle="Aglaonema_Silver",
                    Rating=Rate.Four,
                    SpecieId=types.Single(i => i.Name=="Peperomia").Id,
                    CompanyId=companies.Single(i => i.Name=="Kelowna Furniture").Id
                },new Product
                {
                    Name="Alocasia Palm",
                    Price=249,
                    Quantity=9,
                    ActualCost=184,
                    Description="Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo.",
                    ImgTitle="Alocasia_Palm",
                    Rating=Rate.Three,
                    SpecieId=types.Single(i => i.Name=="Alocasia").Id,
                    CompanyId=companies.Single(i => i.Name=="Kelowna Furniture").Id
                },new Product
                {
                    Name="Syngonium Podophyllum",
                    Price=195,
                    Quantity=17,
                    ActualCost=150,
                    Description="Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud sit amet exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                    ImgTitle="Syngonium_Podophyllum",
                    Rating=Rate.Five,
                    SpecieId=types.Single(i => i.Name=="Peperomia").Id,
                    CompanyId=companies.Single(i => i.Name=="Kelowna Furniture").Id
                },new Product
                {
                    Name="Calathe Medallion",
                    Price=250,
                    Quantity=19,
                    ActualCost=170,
                    Description="Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud sit amet exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                    ImgTitle="Calathe_Medallion",
                    Rating=Rate.Two,
                    SpecieId=types.Single(i => i.Name=="Peperomia").Id,
                    CompanyId=companies.Single(i => i.Name=="Green Park").Id
                },new Product
                {
                    Name="Calathe Plant",
                    Price=125,
                    Quantity=21,
                    ActualCost=100,
                    Description="Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim laborum.",
                    ImgTitle="Calathe",
                    Rating=Rate.Four,
                    SpecieId=types.Single(i => i.Name=="Peperomia").Id,
                    CompanyId=companies.Single(i => i.Name=="Tree House").Id
                },new Product
                {
                    Name="Strelitzia Reginae",
                    Price=80,
                    Quantity=3,
                    ActualCost=50,
                    Description="Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    ImgTitle="Strelitzia_Reginae",
                    Rating=Rate.Five,
                    SpecieId=types.Single(i => i.Name=="Alocasia").Id,
                    CompanyId=companies.Single(i => i.Name=="Green Park").Id
                },
                new Product
                {
                    Name="Dracaena Marginata",
                    Price=135,
                    Quantity=30,
                    ActualCost=100,
                    Description="Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim laborum.",
                    ImgTitle="Dracaena_Marginata",
                    Rating=Rate.Three,
                    SpecieId=types.Single(i => i.Name=="Alocasia").Id,
                    CompanyId=companies.Single(i => i.Name=="Tree House").Id
                },
                new Product
                {
                    Name="Alocasia Cuculata",
                    Price=145,
                    Quantity=10,
                    ActualCost=100,
                    Description="Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    ImgTitle="Alocasia_Cuculata",
                    Rating=Rate.Five,
                    SpecieId=types.Single(i => i.Name=="Alocasia").Id,
                    CompanyId=companies.Single(i => i.Name=="Green Park").Id
                },
                new Product
                {
                    Name="Ficus Microcarpa",
                    Price=125,Quantity=100,
                    ActualCost=100,
                    Description="Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim laborum.",
                    ImgTitle="Ficus_Microcarpa",
                    Rating=Rate.Five,
                    SpecieId=types.Single(i => i.Name=="Banyan").Id,
                    CompanyId=companies.Single(i => i.Name=="Kelowna Furniture").Id
                },
                new Product
                {
                    Name="Elephant Jade",
                    Price=125,
                    Quantity=13,
                    ActualCost=90,
                    Description="Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim laborum.",
                    ImgTitle="Elephant_Jade",
                    Rating=Rate.Four,
                    SpecieId=types.Single(i => i.Name=="Banyan").Id,
                    CompanyId=companies.Single(i => i.Name=="London Pot").Id
                },
                new Product
                {
                    Name="Oxalis Burgundy",
                    Price=175,
                    Quantity=25,
                    ActualCost=150,
                    Description="Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    ImgTitle="Oxalis_Burgundy",
                    Rating=Rate.Five,
                    SpecieId=types.Single(i => i.Name=="Banyan").Id,
                    CompanyId=companies.Single(i => i.Name=="Kelowna Furniture").Id
                }
            };
            if (!context.Products.Any())
            {

                foreach (var product in plants)
                {
                    context.Products.Add(product);
                }
                context.SaveChanges();
            }
            //var users = new User[]
            //{
            //    new User
            //    {
            //        FirstName="Ronald",
            //        LastName="Weasley",
            //        Phone="0123456791",
            //        Email="weasley@gmail.com",
            //    },
            //     new User
            //    {
            //        FirstName="Hermione",
            //        LastName="Granger",
            //        Phone="0123456791",
            //        Email="granger@gmail.com",
            //    },
            //      new User
            //    {
            //        FirstName="Draco",
            //        LastName="Malfoy",
            //        Phone="0987654321",
            //        Email="malfoy@gmail.com",
            //    },
            //       new User
            //    {
            //        FirstName="Luna",
            //        LastName="Lovegood",
            //        Phone="0123456791",
            //        Email="lovegood@gmail.com",
            //    },
            //};
            //if (!context.Users.Any())
            //{
            //    foreach (var user in users)
            //    {
            //        context.Users.Add(user);
            //    }
            //    context.SaveChanges();
            //}
            //var orders = new Order[]
            //{
            //    new Order
            //    {
            //        ProductId=plants.Single(i=>i.Name=="Syngonium Podophyllum").Id,
            //        Quantity=3,
            //        Payment=plants.Single(i=>i.Name=="Syngonium Podophyllum").Price*3,
            //        UserId=users.Single(i=>i.Email=="lovegood@gmail.com").id,
            //        BuyDate= DateTime.Parse("2020-4-7"),
            //    },
            //     new Order
            //    {
            //        ProductId=plants.Single(i=>i.Name=="Elephant Jade").Id,
            //        Quantity=5,
            //        Payment=plants.Single(i=>i.Name=="Elephant Jade").Price*5,
            //        UserId=users.Single(i=>i.Email=="granger@gmail.com").id,
            //        BuyDate= DateTime.Parse("2018-9-10"),
            //    },
            //      new Order
            //    {
            //        ProductId=plants.Single(i=>i.Name=="Alocasia Cuculata").Id,
            //        Quantity=10,
            //        Payment=plants.Single(i=>i.Name=="Alocasia Cuculata").Price*10,
            //        UserId=users.Single(i=>i.Email=="weasley@gmail.com").id,
            //        BuyDate= DateTime.Parse("2022-6-3"),
            //    }, new Order
            //    {
            //        ProductId=plants.Single(i=>i.Name=="Oxalis Burgundy").Id,
            //        Quantity=12,
            //        Payment=plants.Single(i=>i.Name=="Oxalis Burgundy").Price*12,
            //        UserId=users.Single(i=>i.Email=="weasley@gmail.com").id,
            //        BuyDate= DateTime.Parse("2022-6-3"),
            //    }, new Order
            //    {
            //        ProductId=plants.Single(i=>i.Name=="Oxalis Burgundy").Id,
            //        Quantity=21,
            //        Payment=plants.Single(i=>i.Name=="Oxalis Burgundy").Price*21,
            //        UserId=users.Single(i=>i.Email=="malfoy@gmail.com").id,
            //        BuyDate= DateTime.Parse("2021-10-12"),
            //    }, new Order
            //    {
            //        ProductId=plants.Single(i=>i.Name=="Elephant Jade").Id,
            //        Quantity=8,
            //        Payment=plants.Single(i=>i.Name=="Elephant Jade").Price*8,
            //        UserId=users.Single(i=>i.Email=="malfoy@gmail.com").id,
            //        BuyDate= DateTime.Parse("2021-10-12"),
            //    },
            //};
            //if (!context.Orders.Any())
            //{
            //    foreach (var order in orders)
            //    {
            //        context.Orders.Add(order);

            //    }
            //    context.SaveChanges();
            //}
        }
    }
}
