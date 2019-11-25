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
            if (!context.Storages.Any())
            {
                var user = context.Users.FirstOrDefault(user => user.UserName == "toti7");
                var storage = new Storage
                {
                    Pearl = 0,
                    Coral = 0,
                    User = user
                };

                context.Storages.Add(storage);
                context.SaveChanges();
            }
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

        public static void SeedData(AppDbContext context)
        {
            throw new NotImplementedException();
        }
    }
}
