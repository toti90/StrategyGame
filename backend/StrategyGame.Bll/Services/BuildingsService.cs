using StrategyGame.Bll.DTOs;
using StrategyGame.Bll.Interfaces;
using StrategyGame.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.Services
{
    public class BuildingsService : IBuildingsService
    {
        private readonly AppDbContext _context;

        public BuildingsService(AppDbContext context)
        {
            _context = context;
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
    }
}
