﻿using StrategyGame.Bll.DTOs;
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
        public async Task<IEnumerable<BuildingDTO>> GetAllBuildings()
        {
            var userId = await _IUserAccessor.GetCurrentUserId();
            var allbuildingsList = await _context.Buildings.ToListAsync();

            return allbuildingsList.Select(b =>
               new BuildingDTO
               {
                   BuildingId = b.BuildingId,
                   BuildingName = b.BuildingName,
                   Price = b.Price,
                   Messages = generateBuildingtMessages(b),
                   BigImageUrl = b.BigImageUrl
               });

        }
        public async Task<bool> AddNewBuilding(int buildingId)
        {
            var userId = await _IUserAccessor.GetCurrentUserId();
            var user = await _context.Users.Where(u => u.Id == userId).FirstOrDefaultAsync();
            var userExistingBuildingGroups = await _context.BuildingGroups.Where(u => u.UserId == userId).ToListAsync();
            var newBuildings = await _context.NewBuildings.ToListAsync();
            var existInProgressBuilding = newBuildings.Where(nb => userExistingBuildingGroups.Any(uebg => uebg.BuildingGroupId == nb.BuildingGroupId && nb.Round<5)).ToList();
            if (existInProgressBuilding.Count() > 0)
            {
                throw new RestException(HttpStatusCode.Conflict, new { Message = "You have got new building in progress" });
            }
            var userBuildingGroup = await _context.BuildingGroups.Where(bg => bg.BuildingId == buildingId && bg.UserId == userId).FirstOrDefaultAsync();
            if (userBuildingGroup != null)
            {
                var newBuilding = new NewBuilding
                {
                    BuildingGroup = userBuildingGroup
                };
                _context.NewBuildings.Add(newBuilding);
                await _context.SaveChangesAsync();
            }
            else
            {
                var building = await _context.Buildings.Where(b => b.BuildingId == buildingId).FirstOrDefaultAsync();
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
                    BuildingGroup = await _context.BuildingGroups.Where(bg => bg.BuildingId == buildingId && bg.UserId == userId).FirstOrDefaultAsync()
                };
                _context.NewBuildings.Add(newBuilding);
                await _context.SaveChangesAsync();
            }
            return true;
        }

        private List<string> generateBuildingtMessages(Building building)
        {
            var response = new List<string>();
            if (building.AddCorall.HasValue)
            {
                response.Add($"{building.AddCorall.Value} korallt termel körönként");
            }
            if (building.AddPeople.HasValue)
            {
                response.Add($"{building.AddPeople.Value} ember-t ad a népességhez");
            }
            if (building.HotelForArmy.HasValue)
            {
                response.Add($"{building.HotelForArmy.Value} egység számára nyújt szálást");
            }
            return response;
        }
    }
}
