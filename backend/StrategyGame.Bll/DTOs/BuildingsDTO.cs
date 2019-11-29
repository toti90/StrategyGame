using StrategyGame.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Bll.DTOs
{
    public class BuildingDTO
    {
        public int BuildingId { get; set; }
        public string BuildingName { get; set; }
        public int Price { get; set; }
        public List<string> Messages { get; set; }
        public string BigImageUrl { get; set; }
    }
    public class addnewBuildingRequestDTO
    {
        public int buildingId { get; set; }
    }

}
