using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StrategyGame.Model.Entities
{
    public class Building
    {
        public Building()
        {
            BuildingGroups = new HashSet<BuildingGroup>();
        }
        public int BuildingId { get; set; }
        [Required]
        public string BuildingName { get; set; }
        [Required]
        public int Price { get; set; }
        public int? AddCorall { get; set; }
        public int? AddPeople { get; set; }
        public int? HotelForArmy { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<BuildingGroup> BuildingGroups { get; set; }

    }
}
