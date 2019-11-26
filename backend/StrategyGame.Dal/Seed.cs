using Microsoft.AspNetCore.Identity;
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
            if (!context.Developments.Any())
            {
                var developments = new List<Development>
                {
                    new Development
                    {
                        DevelopmentName = "Iszaptraktor",
                        AddCorall = 1.1,
                    },
                    new Development
                    {
                        DevelopmentName = "Iszapkombájn",
                        AddCorall = 1.15,
                    },
                    new Development
                    {
                        DevelopmentName = "Korallfal",
                        AddDefense = 1.2,
                    },
                    new Development
                    {
                        DevelopmentName = "Szonárágyú",
                        AddAttack = 1.2,
                    },
                    new Development
                    {
                        DevelopmentName = "Vízalatti harcművészetek",
                        AddDefense = 1.1,
                        AddAttack = 1.1,
                    },
                    new Development
                    {
                        DevelopmentName = "Alkímia",
                        AddTax = 1.3,
                    },
                };

                context.Developments.AddRange(developments);
                await context.SaveChangesAsync();
            }
            if (!context.DevelopmentGroups.Any())
            {
                var user = context.Users.FirstOrDefault(user => user.UserName == "toti");
                var development = context.Developments.FirstOrDefault(d => d.DevelopmentName == "Iszaptraktor");
                var developmentGroup = new DevelopmentGroup
                {
                    User = user,
                    Development = development
                };

                context.DevelopmentGroups.Add(developmentGroup);
                await context.SaveChangesAsync();
            }
            if (!context.NewDevelopments.Any())
            {
                var development = context.Developments.FirstOrDefault(d => d.DevelopmentName == "Iszaptraktor");
                var user = context.Users.Include(p => p.DevelopmentGroups).Where(user => user.UserName == "toti").First();
                var developmentGroup = user.DevelopmentGroups.Where(dg => dg.Development == development).First();
                var newDevelopment = new NewDevelopment
                {
                    DevelopmentGroup = developmentGroup
                };

                context.NewDevelopments.Add(newDevelopment);
                await context.SaveChangesAsync();
            }
            if (!context.Units.Any())
            {
                var units = new List<Unit>
                {
                    new Unit
                    {
                        UnitName = "Rohamfóka",
                        Attack = 6,
                        Defense = 2,
                        Price = 50,
                        Salary = 1,
                        Food = 1
                    },
                    new Unit
                    {
                        UnitName = "Csatacsikó",
                        Attack = 2,
                        Defense = 6,
                        Price = 50,
                        Salary = 1,
                        Food = 1
                    },
                    new Unit
                    {
                        UnitName = "Lézercápa",
                        Attack = 5,
                        Defense = 5,
                        Price = 100,
                        Salary = 3,
                        Food = 2
                    },
                };

                context.Units.AddRange(units);
                await context.SaveChangesAsync();
            }
            if (!context.Legions.Any())
            {
                var unit1 = context.Units.FirstOrDefault(d => d.UnitName == "Lézercápa");
                var unit2 = context.Units.FirstOrDefault(d => d.UnitName == "Csatacsikó");
                var user = context.Users.FirstOrDefault(user => user.UserName == "toti");
                var legion = new List<Legion>
                {
                    new Legion
                    {
                        User = user,
                        Unit = unit1,
                        Amount = 10
                    },
                    new Legion
                    {
                        User = user,
                        Unit = unit2,
                        Amount = 20
                    }

                };

                context.Legions.AddRange(legion);
                await context.SaveChangesAsync();
            }
            if (!context.FightGroups.Any())
            {
                var unit1 = context.Units.FirstOrDefault(d => d.UnitName == "Lézercápa");
                var user = context.Users.Include(p => p.Legions).Where(user => user.UserName == "toti").First();
                var attackedUser = context.Users.FirstOrDefault(user => user.UserName == "toti32");
                var legion = user.Legions.Where(l => l.Unit == unit1).First();
                var fightGroup = new FightGroup
                {
                    PartOfLegion = 0.5,
                    Legion = legion,
                    AttackedUserId = attackedUser.Id
                };

                context.FightGroups.Add(fightGroup);
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
