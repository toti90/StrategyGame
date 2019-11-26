using StrategyGame.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Bll.DTOs
{
    public class GameHomeScreenResponseDTO
    {
        public int Round { get; set; }
        public int Place { get; set; }
        public ICollection<LegionHomeScreenDTO> Legions { get; set; }
        public Storage Storage { get; set; }
        public ICollection<BuildingGroupHomeScreenDTO> BuildingGroups { get; set; }
    }

    public class LegionHomeScreenDTO
    {
        public string UnitName { get; set; }
        public int Amount { get; set; }
        public int Salary { get; set; }
        public int Food { get; set; }
        public string imageUrl { get; set; }
        public int LegionId { get; set; }
        public virtual Legion Legion { get; set; }
    }

    public class BuildingGroupHomeScreenDTO
    {
        public string BuildingName { get; set; }
        public string SmaillImageUrl { get; set; }
        public int Amount { get; set; }
        public int AddCorall { get; set; }
        public int AddPearl { get; set; }
        public int HotelForArmy { get; set; }
        public bool inProgress { get; set; }
    }
}
