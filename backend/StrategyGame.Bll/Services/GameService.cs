using Microsoft.EntityFrameworkCore;
using StrategyGame.Bll.DTOs;
using StrategyGame.Bll.Interfaces;
using StrategyGame.Dal;
using StrategyGame.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.Services
{
    public class GameService : IGameService
    {
        private readonly AppDbContext _context;
        private readonly IUserAccessor _IUserAccessor;

        public GameService(AppDbContext context, IUserAccessor UserAccessor)
        {
            _context = context;
            _IUserAccessor = UserAccessor;
        }
        public async Task<GameHomeScreenResponseDTO> getHomeScreen()
        {
            var game =  _context.Games.FirstOrDefault(p => p.inProgress);
            var user = await _context.Users.Include(u => u.Legions).Include(u => u.BuildingGroups).Include(u => u.DevelopmentGroups)
                .Where(u => u.Id == _IUserAccessor.GetCurrentUserId()).FirstOrDefaultAsync();

            var allUnits = _context.Units.ToList();
            var responseLegions = new List<LegionHomeScreenDTO>();
            foreach (var unit in allUnits)
            {
                var userLegion = user.Legions.Where(l => l.UnitId == unit.UnitId).FirstOrDefault();
                var legionHomeScreen = new LegionHomeScreenDTO
                {
                    UnitId = unit.UnitId,
                    Amount = userLegion != null ? userLegion.Amount : 0,
                    imageUrl = unit.ImageUrl
                };
                responseLegions.Add(legionHomeScreen);
            }


            var storage = _context.Storages.Where(s => s.UserId == user.Id).FirstOrDefault();
            var storageHomeScreen = new StorageHomeScreenDTO
            {
                Pearl = storage.Pearl,
                Coral = storage.Coral
            };

            var allBuildings = _context.Buildings.ToList();
            var responseBuildings = new List<BuildingGroupHomeScreenDTO>();
            foreach (var building in allBuildings)
            {
                var userBuildingGroups = user.BuildingGroups.Where(bg => bg.BuildingId == building.BuildingId).FirstOrDefault();
                var userBuildingGroupsCount = userBuildingGroups != null ? userBuildingGroups.Amount : 0;
                int userNewBuildingsCount;
                if (userBuildingGroups != null)
                {
                    userNewBuildingsCount = _context.NewBuildings.Where(nb => nb.BuildingGroupId == userBuildingGroups.BuildingGroupId && nb.Round < 15).Count();
                } else
                {
                    userNewBuildingsCount = 0;
                }
                
                var buildingGroupHomeScreen = new BuildingGroupHomeScreenDTO
                {
                    BuildingId = building.BuildingId,
                    Amount = userBuildingGroupsCount,
                    SmallImageUrl = building.SmallImageUrl,
                    BigImageUrl = building.BigImageUrl,
                    inProgress = userNewBuildingsCount
                };
                responseBuildings.Add(buildingGroupHomeScreen);
            }

            var response = new GameHomeScreenResponseDTO
            {
                Round = game.Round,
                Place = user.Place,
                Legions = responseLegions,
                Storage = storageHomeScreen,
                BuildingGroups = responseBuildings,
                CoralPerRound = Convert.ToInt32(CalculateCorall(user)),
                PearlPerRound = Convert.ToInt32(CalculatePearl(user))
            };
            return response;
        }

        public double CalculateCorall(User user)
        {
            var numberOfCorralForFood = _context.Legions.Include(l => l.Unit)
                .Where(l => l.UserId == user.Id)
                .ToList()
                .Aggregate(0, (x, y) => x + y.Amount * y.Unit.Food);

            var numberOfCoralFromBuilding = _context.BuildingGroups.Include(bg => bg.Building)
                .Where(bg => bg.UserId == user.Id && bg.Building.AddCorall.HasValue)
                .ToList()
                .Aggregate(0, (x, y) => x + y.Amount * y.Building.AddCorall.Value);

            var numberOfCoralFromDevelopment = _context.DevelopmentGroups.Include(dg => dg.Development)
                .Where(dg => dg.UserId == user.Id && dg.Development.AddCorall.HasValue)
                .ToList()
                .Aggregate(1D, (x, y) => x * Math.Pow(y.Development.AddCorall.Value, y.Amount));

            return Math.Round((numberOfCoralFromBuilding - numberOfCorralForFood)*numberOfCoralFromDevelopment, 0);
        }

        public double CalculatePearl(User user)
        {
            var numberOfPearlForFood = _context.Legions.Include(l => l.Unit)
                .Where(l => l.UserId == user.Id)
                .ToList()
                .Aggregate(0, (x, y) => x + y.Amount * y.Unit.Salary);

            var numberOfPearlFromBuilding = _context.BuildingGroups.Include(bg => bg.Building)
                .Where(bg => bg.UserId == user.Id && bg.Building.AddPeople.HasValue)
                .ToList()
                .Aggregate(0, (x, y) => x + y.Amount * y.Building.AddPeople.Value * 25);

            var numberOfPearlFromDevelopment = _context.DevelopmentGroups.Include(dg => dg.Development)
                .Where(dg => dg.UserId == user.Id && dg.Development.AddTax.HasValue)
                .ToList()
                .Aggregate(1D, (x, y) => x * Math.Pow(y.Development.AddTax.Value, y.Amount));

            return Math.Round(numberOfPearlFromBuilding * numberOfPearlFromDevelopment - numberOfPearlForFood, 0);
        }
    }
}
