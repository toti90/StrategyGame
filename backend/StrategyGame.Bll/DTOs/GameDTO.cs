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
        public StorageHomeScreenDTO Storage { get; set; }
        public ICollection<BuildingGroupHomeScreenDTO> BuildingGroups { get; set; }
        public int PearlPerRound { get; set; }
        public int CoralPerRound { get; set; }
    }

    public class LegionHomeScreenDTO
    {
        public int UnitId { get; set; }
        public int Amount { get; set; }
        public string imageUrl { get; set; }
    }

    public class BuildingGroupHomeScreenDTO
    {
        public int BuildingId { get; set; }
        public string SmallImageUrl { get; set; }
        public string BigImageUrl { get; set; }
        public int Amount { get; set; }
        public int inProgress { get; set; }
    }

    public class StorageHomeScreenDTO
    {
        public int Pearl { get; set; }
        public int Coral { get; set; }
    }
}
