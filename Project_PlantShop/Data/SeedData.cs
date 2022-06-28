using Project_PlantShop.Data;
using Project_PlantShop.Models;

namespace Project_PlantShop.Data
{
    public class SeedData
    {
        public static void AddData(PlantContext context)
        {
            context.Database.EnsureCreated();
            if (context.Plants.Any())
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
            var plants = new Plant[]
            {
                new Plant
                {
                    Name="Opuntia Microdaysys",
                    Price=125,
                    RealPrice=100,
                    Quantity=100,
                    Description="Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim laborum.",
                    ImgTitle="/Images/product/Opuntia_Microdaysys.jpg",
                    Rating=Rate.Five,
                    SpecieId=types.Single(i => i.Name=="Succulents").Id,
                },
                new Plant
                {
                    Name="Cactus Flat",
                    Price=160,
                    RealPrice=150,
                    Quantity=30,
                    Description="Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim laborum.",
                    ImgTitle="/Images/product/Cactus_Flat.jpg",
                    Rating=Rate.Five,
                    SpecieId=types.Single(i => i.Name=="Succulents").Id,
                },new Plant
                {
                    Name="Acheveria Agave",
                    Price=55,
                    RealPrice=40,
                    Quantity=10,
                    Description="Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim laborum.",
                    ImgTitle="/Images/product/Acheveria_Agave.jpg",
                    Rating=Rate.Two,
                    SpecieId=types.Single(i => i.Name=="Succulents").Id,
                },new Plant
                {
                    Name="Cylindrical Snake",
                    Price=175,
                    RealPrice=110,
                    Quantity=10,
                    Description="Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim laborum.",
                    ImgTitle="/Images/product/Cyclindrical_Snake.jpg",
                    Rating=Rate.Three,
                    SpecieId=types.Single(i => i.Name=="Succulents").Id,
                },new Plant
                {
                    Name="Aglaonema Silver",
                    Price=150,
                    RealPrice=100,
                    Quantity=12,
                    Description="Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    ImgTitle="/Images/product/Aglaonema_Silver.jpg",
                    Rating=Rate.Four,
                    SpecieId=types.Single(i => i.Name=="Peperomia").Id,
                },new Plant
                {
                    Name="Alocasia Palm",
                    Price=249,
                    RealPrice=220,
                    Quantity=9,
                    Description="Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo.",
                    ImgTitle="/Images/product/Alocasia_Palm.jpg",
                    Rating=Rate.Three,
                    SpecieId=types.Single(i => i.Name=="Alocasia").Id,
                },new Plant
                {
                    Name="Syngonium Podophyllum",
                    Price=195,
                    RealPrice=180,
                    Quantity=17,
                    Description="Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud sit amet exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                    ImgTitle="/Images/product/Syngonium_Podophyllum.jpg",
                    Rating=Rate.Five,
                    SpecieId=types.Single(i => i.Name=="Peperomia").Id,
                },new Plant
                {
                    Name="Calathe Medallion",
                    Price=250,
                    RealPrice=200,
                    Quantity=19,
                    Description="Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud sit amet exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                    ImgTitle="/Images/product/Calathe_Medallion.jpg",
                    Rating=Rate.Two,
                    SpecieId=types.Single(i => i.Name=="Peperomia").Id,
                },new Plant
                {
                    Name="Calathe Plant",
                    Price=125,
                    RealPrice=100,
                    Quantity=21,
                    Description="Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim laborum.",
                    ImgTitle="/Images/product/Calathe.jpg",
                    Rating=Rate.Four,
                    SpecieId=types.Single(i => i.Name=="Peperomia").Id,
                },new Plant
                {
                    Name="Strelitzia Reginae",
                    Price=80,
                    RealPrice=50,
                    Quantity=3,
                    Description="Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    ImgTitle="/Images/product/Strelitzia_Reginae.jpg",
                    Rating=Rate.Five,
                    SpecieId=types.Single(i => i.Name=="Alocasia").Id,
                },
                new Plant
                {
                    Name="Dracaena Marginata",
                    Price=135,
                    RealPrice=120,
                    Quantity=30,
                    Description="Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim laborum.",
                    ImgTitle="/Images/product/Dracaena_Marginata.jpg",
                    Rating=Rate.Three,
                    SpecieId=types.Single(i => i.Name=="Alocasia").Id,
                },
                new Plant
                {
                    Name="Alocasia Cuculata",
                    Price=145,
                    RealPrice=140,
                    Quantity=10,
                    Description="Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    ImgTitle="/Images/product/Alocasia_Cuculata.jpg",
                    Rating=Rate.Five,
                    SpecieId=types.Single(i => i.Name=="Alocasia").Id,
                },
                new Plant
                {
                    Name="Ficus Microcarpa",
                    Price=125,
                    RealPrice=100,
                    Quantity=100,
                    Description="Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim laborum.",
                    ImgTitle="/Images/product/Ficus_Microcarpa.jpg",
                    Rating=Rate.Five,
                    SpecieId=types.Single(i => i.Name=="Banyan").Id,
                },
                new Plant
                {
                    Name="Elephant Jade",
                    Price=125,
                    Quantity=13,
                    RealPrice=100,
                    Description="Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim laborum.",
                    ImgTitle="/Images/product/Elephant_Jade.jpg",
                    Rating=Rate.Four,
                    SpecieId=types.Single(i => i.Name=="Banyan").Id,
                },
                new Plant
                {
                    Name="Oxalis Burgundy",
                    Price=175,
                    RealPrice=150,
                    Quantity=25,
                    Description="Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    ImgTitle="/Images/product/Oxalis_Burgundy.jpg",
                    Rating=Rate.Five,
                    SpecieId=types.Single(i => i.Name=="Banyan").Id,
                }
            };

            foreach (var product in plants)
            {
                context.Plants.Add(product);
            }
            context.SaveChanges();
            var staffs = new Staff[]
            {
                new Staff
                {
                    FirstMidName="Ronald",
                    LastName="Weasley",
                    Phone="0123456791",
                    decription="Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    imageTitle="/Images/Staff/Ronald.png",
                    Dob=DateTime.Parse("2010-9-16"),

                },
                 new Staff
                {
                    FirstMidName="Luna",
                    LastName="Lovegood",
                    Phone="0567911234",
                    decription="Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    imageTitle="/Images/Staff/Luna.png",
                    Dob=DateTime.Parse("2010-9-16"),

                },
                  new Staff
                {
                    FirstMidName="Hermione",
                    LastName="Granger",
                    Phone="0456712391",
                    decription="Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    imageTitle="/Images/Staff/Hermione.png",
                    Dob=DateTime.Parse("2010-9-16"),

                }
            };


            foreach (var product in staffs)
            {
                context.Staffs.Add(product);
            }
            context.SaveChanges();
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
