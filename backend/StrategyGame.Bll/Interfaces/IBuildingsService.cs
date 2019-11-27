using StrategyGame.Bll.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.Interfaces
{
    public interface IBuildingsService
    {
        Task<BuildingsResponseDTO> GetAllBuildings();
        Task<bool> AddNewBuilding(int buildingId);
    }
}
