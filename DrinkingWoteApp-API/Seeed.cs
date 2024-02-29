using DrinkingWoteApp_API.Models;
using DrinkingWoteApp_API.Data;
using DrinkingWoteApp_API.Models;
using System.Diagnostics.Metrics;
using Microsoft.AspNetCore.Identity;

namespace DrinkingWoteApp_API
{
    public class Seed
    {
        private readonly AppDbContext dataContext;
        public Seed(AppDbContext context)
        {
            this.dataContext = context;
        }
        //public void SeedDataContext()
        //{
        //    if (!dataContext.Users.Any())
        //    {
        //        var users = new List<User>()
        //        {
        //            //user 1
        //            new User()
        //            {
        //                Consument = new Consument()
        //                {
        //                    FirstName = "Nadine",
        //                    LastName = "Sarah",
        //                    JoinDate = new DateTime(2024,1,1),
        //                    Balance = 0,
        //                    Orders = new List<Order>(){},
        //                    Address = new Address()
        //                    {
        //                        Perumahan = new Perumahan()
        //                        {
        //                            Perumahan_Name = "Marina Mas"
        //                        },
        //                        Block = "A5 No. 6",
        //                        RT_RW = "01/07",
        //                        Kelurahan = "Tanjung Uncang",
        //                        Kecamatan = "Batu Aji"
        //                    },
        //                    Reviews = new List<Review>(){ }
        //                    //ConsumenOrders = new List<ConsumentOrder>(){ }
        //                },
        //                User_Name = "Sarah01",
        //                Password = "Sarah123",
        //                Email = "Sarah@gmail.com",
        //                MobilePhone = "+62812345678",
        //                BirthTime = new DateTime(1998,8,9)
                        
        //            },
        //            new User()
        //            {
        //                Consument = new Consument()
        //                {
        //                    FirstName = "Michael",
        //                    LastName = "Simbolon",
        //                    JoinDate = new DateTime(2024,2,1),
        //                    Balance = 0,
        //                    Orders = new List<Order>(){},
        //                    Address = new Address()
        //                    {
        //                        Perumahan = new Perumahan()
        //                        {
        //                            Perumahan_Name = "Laguna Indah"
        //                        },
        //                        Block = "A10 No 7",
        //                        RT_RW = "02/11",
        //                        Kelurahan = "Tanjung Uncang",
        //                        Kecamatan = "Batu Aji"
        //                    },
        //                    Reviews = new List<Review>(){ }
        //                    //ConsumenOrders = new List<ConsumentOrder>(){ }
        //                },
        //                User_Name = "Michael01",
        //                Password = "Michael123",
        //                Email = "michael@gmail.com",
        //                MobilePhone = "+62887654321",
        //                BirthTime = new DateTime(1997,12,10)
        //            }

        //        };
        //        var perumahan = new List<Perumahan>()
        //        {
        //            new Perumahan(){Perumahan_Name = "Marina Mas"},
        //            new Perumahan(){Perumahan_Name = "Laguna Indah"}
        //        };

        //        var orders = new List<Order>()
        //        {
        //            new Order()
        //            {
        //                Consument = new Consument() { },
        //                StatusOrder = "PROCESS",
        //                Qty = 1,
        //                TimeOrder = new DateTime(2024,7,2, 09, 20, 00),
        //                OrderDone = new DateTime(2024,7,2, 10,01,00),
        //                PaymentMethod = "CASH",
        //                PaymentStatus = "DONE",
        //                Bill = new Bill()
        //                {
        //                    PaymentMethod = "CASH",
        //                    TotalPaid = 5000,
        //                    //Order_Id = 1,
        //                    Qty = 1,
        //                    PaymentDate = new DateTime(2024,7,2, 10,01,00),
        //                },
        //                Review = new Review()
        //                {
        //                    RatingStar = 4,
        //                    Description = "Pelayanan Bagus",
        //                    Order_Id = 1
        //                },
        //                Crew = new CrewMember()
        //                {
        //                    FirstName = "Budi",
        //                    LastName = "Yanto",
        //                    CrewStatus = "ACTIVE",
        //                }
        //            }

        //        };
        //        dataContext.Users.AddRange(users);
        //        dataContext.Perumahans.AddRange(perumahan);
        //        dataContext.SaveChanges();
        //    }
        //    if (!dataContext.Orders.Any())
        //    {
        //        var orders = new List<Order>()
        //        {
        //            new Order()
        //            {
        //                Consument = new Consument() { },
        //                StatusOrder = "PROCESS",
        //                Qty = 1,
        //                TimeOrder = new DateTime(2024,7,2, 09, 20, 00),
        //                OrderDone = new DateTime(2024,7,2, 10,01,00),
        //                PaymentMethod = "CASH",
        //                PaymentStatus = "DONE",
        //                Bill = new Bill()
        //                {
        //                    PaymentMethod = "CASH",
        //                    TotalPaid = 5000,
        //                    //Order_Id = 1,
        //                    Qty = 1,
        //                    PaymentDate = new DateTime(2024,7,2, 10,01,00),
        //                },
        //                Review = new Review()
        //                {
        //                    RatingStar = 4,
        //                    Description = "Pelayanan Bagus",
        //                    Order_Id = 1
        //                },
        //                Crew = new CrewMember()
        //                {
        //                    FirstName = "Budi",
        //                    LastName = "Yanto",
        //                    CrewStatus = "ACTIVE",
        //                }
        //            }

        //        };
        //        dataContext.Orders.AddRange(orders);
        //        dataContext.SaveChanges();
        //    }
        //}

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();
                string adminUserEmail = "michael@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new User()
                    {
                        UserName = "michael123",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                        Password = "michael123",
                        MobilePhone = "08133333333"
                        
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string appUserEmail = "nadine@gmail.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new User()
                    {
                        UserName = "nadine-user",
                        Email = appUserEmail,
                        EmailConfirmed = true,
                        Password = "nadine123",
                        MobilePhone = "0812222222",
                        Consument = new Consument()
                        {
                            FirstName = "Nadine",
                            LastName = "Sarah",
                            JoinDate = new DateTime(2024-02-29),
                            Balance = 10000
                        }
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}


