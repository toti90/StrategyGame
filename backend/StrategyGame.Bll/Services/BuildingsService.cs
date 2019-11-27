using StrategyGame.Bll.DTOs;
using StrategyGame.Bll.Interfaces;
using StrategyGame.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrategyGame.Model.Entities;
using Microsoft.EntityFrameworkCore;
using StrategyGame.Bll.Errors;
using System.Net;

namespace StrategyGame.Bll.Services
{
    public class BuildingsService : IBuildingsService
    {
        private readonly AppDbContext _context;
        private readonly IUserAccessor _IUserAccessor;

        public BuildingsService(AppDbContext context, IUserAccessor userAccessor)
        {
            _context = context;
            _IUserAccessor = userAccessor;
        }
        public BuildingsResponseDTO getAllBuildings()
        {
            var allBuildings = _context.Buildings.ToList();
            var response = new List<BuildingDTO>();
            foreach (var building in allBuildings)
            {
                var buildingDTO = new BuildingDTO
                {
                    BuildingId = building.BuildingId,
                    BuildingName = building.BuildingName,
                    Price = building.Price,
                    AddCoral = building.AddCorall,
                    AddPeople = building.AddPeople,
                    HotelForArmy = building.HotelForArmy,
                    BigImageUrl = building.BigImageUrl
                };
                response.Add(buildingDTO);
            }
            return new BuildingsResponseDTO { Buildings = response};

        }
        public async Task<bool> addNewBuilding(int buildingId)
        {
            var userId = _IUserAccessor.GetCurrentUserId();
            var user = _context.Users.Where(u => u.Id == userId).FirstOrDefault();
            var userExistingBuildingGroups = await _context.BuildingGroups.Where(u => u.UserId == userId).ToListAsync();
            var newBuildings = await _context.NewBuildings.ToListAsync();
            var existInProgressBuilding = newBuildings.Where(nb => userExistingBuildingGroups.Any(uebg => uebg.BuildingGroupId == nb.BuildingGroupId)).ToList();
            if (existInProgressBuilding.Count() > 0)
            {
                throw new RestException(HttpStatusCode.Conflict, new { Message = "You have got new building in progress" });
            }
            var userBuildingGroup = _context.BuildingGroups.Where(bg => bg.BuildingId == buildingId && bg.UserId == userId).FirstOrDefault();
            if (userBuildingGroup != null)
            {
                var newBuilding = new NewBuilding
                {
                    BuildingGroup = userBuildingGroup
                };
                _context.NewBuildings.Add(newBuilding);
                _context.SaveChanges();
            }
            else
            {
                var building = _context.Buildings.Where(b => b.BuildingId == buildingId).FirstOrDefault();
                if (building == null)
                {
                    throw new RestException(HttpStatusCode.BadRequest, new { message = "unknown buildingId" });
                }
                var newBuildingGroup = new BuildingGroup
                {
                    Building = building,
                    User = user
                };
                _context.BuildingGroups.Add(newBuildingGroup);
                await _context.SaveChangesAsync();
                var newBuilding = new NewBuilding
                {
                    BuildingGroup = _context.BuildingGroups.Where(bg => bg.BuildingId == buildingId && bg.UserId == userId).FirstOrDefault()
                };
                _context.NewBuildings.Add(newBuilding);
                await _context.SaveChangesAsync();
            }
            return true;
        }


    }
}
