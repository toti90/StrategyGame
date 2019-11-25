﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
                await context.SaveChangesAsync();
            }
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
                await context.SaveChangesAsync();
            }
            if (!context.BuildingGroups.Any())
            {
                var user = context.Users.FirstOrDefault(user => user.UserName == "toti");
                var building = context.Buildings.FirstOrDefault(building => building.BuildingName == "Áramlásirányító");
                var buildingGroup = new BuildingGroup
                {
                    User = user,
                    Building = building
                };

                context.BuildingGroups.Add(buildingGroup);
                await context.SaveChangesAsync();
            }
             if (!context.NewBuildings.Any())
            {
                var building = context.Buildings.FirstOrDefault(building => building.BuildingName == "Áramlásirányító");
                var newUser = context.Users.Include(p => p.BuildingGroups).Where(user => user.UserName == "toti").First();
                var buildingGroup = newUser.BuildingGroups.Where(bg => bg.Building == building).First();
                var newBuilding = new NewBuilding
                {
                    BuildingGroup = buildingGroup
                };

                context.NewBuildings.Add(newBuilding);
                await context.SaveChangesAsync();
            }

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

        public async static void SeedStorages(AppDbContext context)
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
                await context.SaveChangesAsync();
            }
        }

        public async static void SeedBuildings(AppDbContext context)
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
                await context.SaveChangesAsync();
            }
        }

        public async static void SeedBuildingGroups(AppDbContext context)
        {
            if (!context.BuildingGroups.Any())
            {
                var user = context.Users.FirstOrDefault(user => user.UserName == "toti");
                var building = context.Buildings.FirstOrDefault(building => building.BuildingName == "Áramlásirányító");
                var buildingGroup = new BuildingGroup
                {
                    User = user,
                    Building = building
                };

                context.BuildingGroups.Add(buildingGroup);
                await context.SaveChangesAsync();
            }
        }

        public static void SeedNewBuildings(AppDbContext context)
        {
            if (!context.NewBuildings.Any())
            {
                var building = context.Buildings.FirstOrDefault(building => building.BuildingName == "Áramlásirányító");
                var newUser = context.Users.FirstOrDefault(user => user.UserName == "toti");
                var buildingGroup = newUser.BuildingGroups.FirstOrDefault(bg => bg.Building == building);
                var newBuilding = new NewBuilding
                {
                    BuildingGroup = null
                };

                context.NewBuildings.Add(newBuilding);
            }
        }
    }
}
