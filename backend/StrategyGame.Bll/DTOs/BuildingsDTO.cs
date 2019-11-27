using StrategyGame.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Bll.DTOs
{
    public class BuildingsResponseDTO
    {
        public ICollection<BuildingDTO> Buildings { get; set; }
    }

    public class BuildingDTO
    {
        public int BuildingId { get; set; }
        public string BuildingName { get; set; }
        public int Price { get; set; }
        public int? AddCoral { get; set; }
        public int? AddPeople { get; set; }
        public int? HotelForArmy { get; set; }
        public string BigImageUrl { get; set; }
    }
    public class addnewBuildingRequestDTO
    {
        public int buildingId { get; set; }
    }

}
