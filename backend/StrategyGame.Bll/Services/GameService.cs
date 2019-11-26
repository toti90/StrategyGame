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
                    Amount = userBuildingGroups != null ? userBuildingGroups.Amount : 0,
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
                BuildingGroups = responseBuildings
            };
            return response;
        }
    }
}
