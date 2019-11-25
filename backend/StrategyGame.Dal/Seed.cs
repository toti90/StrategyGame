using Microsoft.AspNetCore.Identity;
using StrategyGame.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Dal
{
    public class Seed
    {
        public static async Task SeedData(AppDbContext context, UserManager<User> userManager)
        {

            SeedUsers(userManager);
            SeedStorages(context);
            SeedBuildings(context);
            await context.SaveChangesAsync();

        }

        public async static void SeedUsers(UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {
                var users = new List<User>
                {
                    new User
                    {
                        UserName = "toti",
                        CountryName = "HelloWorld",
                        Place = 0
                    },
                    new User
                    {
                        UserName = "ricsi",
                        CountryName = "HelloWorld2",
                        Place = 0
                    },
                    new User
                    {
                        UserName = "toti32",
                        CountryName = "HelloWorld3",
                        Place = 0
                    }
                };
                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }
            }
        }

        public static void SeedStorages(AppDbContext context)
        {
            if (!context.Storages.Any())
            {
                var user = context.Users.FirstOrDefault(user => user.UserName == "toti");
                var storage = new Storage
                {
                    Pearl = 0,
                    Coral = 0,
                    User = user
                };

                context.Storages.Add(storage);
            }
        }

        public static void SeedBuildings(AppDbContext context)
        {
            if (!context.Buildings.Any())
            {
                var buildings = new List<Building>
                {
                    new Building
                    {
                        BuildingName = "Áramlásirányító",
                        Price = 1000,
                        AddPeople = 50,
                        AddCorall = 200
                    },
                    new Building
                    {
                        BuildingName = "Zátonyvár",
                        Price = 1000,
                        HotelForArmy = 200
                    }
                };

                context.Buildings.AddRange(buildings);
            }
        }
    }
}
