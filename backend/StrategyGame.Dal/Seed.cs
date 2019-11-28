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

            await SeedUsers(userManager);

            await SeedStorages(context);

            await SeedBuildings(context);

            await SeedBuildingGroups(context);

            await SeedNewBuildings(context);

            await SeedDevelopments(context);

            await SeedDevelopmentGroups(context);

            await SeedNewDeveleopments(context);

            await SeedUnits(context);

            await SeedLegion(context);

            await SeedFightGroups(context);

            await SeedGame(context);

            await SeedRanglistCollection(context);
        }

        private async static Task SeedGame(AppDbContext context)
        {
            if (!context.Games.Any())
            {

                var game = new Game
                {
                    Round = 1
                };

                context.Games.Add(game);
                await context.SaveChangesAsync();
            }
        }

        private async static Task SeedFightGroups(AppDbContext context)
        {
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

        private async static Task SeedLegion(AppDbContext context)
        {
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
        }

        private async static Task SeedUnits(AppDbContext context)
        {
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
                        Food = 1,
                        AddPoint = 5,
                        ImageUrl = "../../../../../assets/seal.svg"
                    },
                    new Unit
                    {
                        UnitName = "Csatacsikó",
                        Attack = 2,
                        Defense = 6,
                        Price = 50,
                        Salary = 1,
                        Food = 1,
                        AddPoint = 5,
                        ImageUrl = "../../../../../assets/seahorse.svg"
                    },
                    new Unit
                    {
                        UnitName = "Lézercápa",
                        Attack = 5,
                        Defense = 5,
                        Price = 100,
                        Salary = 3,
                        Food = 2,
                        AddPoint = 10,
                        ImageUrl = "../../../../../assets/shark.svg"
                    },
                };

                context.Units.AddRange(units);
                await context.SaveChangesAsync();
            }
        }

        private async static Task SeedNewDeveleopments(AppDbContext context)
        {
            if (!context.NewDevelopments.Any())
            {
                var user = context.Users.Include(p => p.DevelopmentGroups).Where(user => user.UserName == "toti").First();
                var development1 = context.Developments.FirstOrDefault(d => d.DevelopmentName == "Iszaptraktor");
                var developmentGroup1 = user.DevelopmentGroups.Where(dg => dg.Development == development1).First();
                var development2 = context.Developments.FirstOrDefault(d => d.DevelopmentName == "Szonárágyú");
                var developmentGroup2 = user.DevelopmentGroups.Where(dg => dg.Development == development2).First();
                var newDevelopment = new List<NewDevelopment>
                {
                    new NewDevelopment
                    {
                        DevelopmentGroup = developmentGroup1,
                        Round = 15
                    },
                    new NewDevelopment
                    {
                        DevelopmentGroup = developmentGroup2,
                        Round = 3
                    }
                };

                context.NewDevelopments.AddRange(newDevelopment);
                await context.SaveChangesAsync();
            }
            
        }

        private async static Task SeedDevelopmentGroups(AppDbContext context)
        {
            if (!context.DevelopmentGroups.Any())
            {
                var user = context.Users.FirstOrDefault(user => user.UserName == "toti");
                var development1 = context.Developments.FirstOrDefault(d => d.DevelopmentName == "Iszaptraktor");
                var development2 = context.Developments.FirstOrDefault(d => d.DevelopmentName == "Szonárágyú");
                var developmentGroup = new List<DevelopmentGroup>
                {
                    new DevelopmentGroup
                    {
                         User = user,
                         Development = development1,
                         Amount = 1
                    },
                    new DevelopmentGroup
                    {
                         User = user,
                         Development = development2
                    }
                }; 
                context.DevelopmentGroups.AddRange(developmentGroup);
                await context.SaveChangesAsync();
            }
        }

        public async static Task SeedUsers(UserManager<User> userManager)
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

        public async static Task SeedStorages(AppDbContext context)
        {
            if (!context.Storages.Any())
            {
                
                var user = context.Users.FirstOrDefault(user => user.UserName == "toti");
                var user2 = context.Users.FirstOrDefault(user => user.UserName == "toti32");
                var user3 = context.Users.FirstOrDefault(user => user.UserName == "ricsi");
                var storage = new List<Storage>
                {
                     new Storage
                     {
                         User = user
                     },
                     new Storage
                     {
                         User = user2
                     },
                     new Storage
                     {
                         User = user3
                     }
                };
                context.Storages.AddRange(storage);
                await context.SaveChangesAsync();
            }
        }

        public async static Task SeedBuildings(AppDbContext context)
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
                        AddCorall = 200,
                        BigImageUrl = "../../../../../assets/aramlasiranyito@2x.png",
                        SmallImageUrl = "../../../../../assets/aramlasiranyito.png"
                    },
                    new Building
                    {
                        BuildingName = "Zátonyvár",
                        Price = 1000,
                        HotelForArmy = 200,
                        BigImageUrl = "../../../../../assets/zatonyvar@2x.png",
                        SmallImageUrl = "../../../../../assets/zatonyvar.png"
                    }
                };

                context.Buildings.AddRange(buildings);
                await context.SaveChangesAsync();
            }
        }

        public async static Task SeedBuildingGroups(AppDbContext context)
        {
            if (!context.BuildingGroups.Any())
            {
                var user = context.Users.FirstOrDefault(user => user.UserName == "toti");
                var building = context.Buildings.FirstOrDefault(building => building.BuildingName == "Áramlásirányító");
                var buildingGroup = new BuildingGroup
                {
                    User = user,
                    Building = building,
                    Amount = 1
                };

                context.BuildingGroups.Add(buildingGroup);
                await context.SaveChangesAsync();
            }
        }

        public async static Task SeedNewBuildings(AppDbContext context)
        {
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

        private async static Task SeedDevelopments(AppDbContext context)
        {
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
        }

        public async static Task SeedRanglistCollection(AppDbContext context)
        {
            if (!context.RanglistCollections.Any())
            {
                var game = await context.Games.FirstOrDefaultAsync(g => g.inProgress == true);
                var ranglisCollection = new RanglistCollection
                {
                    Game = game,
                    Round = game.Round
                };

                context.RanglistCollections.Add(ranglisCollection);
                await context.SaveChangesAsync();
            }
        }
    }
}
