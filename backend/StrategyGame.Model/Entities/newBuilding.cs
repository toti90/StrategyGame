using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Model.Entities
{
    public class NewBuilding
    {
        public int newBuildingId { get; set; }
        public int Round { get; set; }
        public int BuildingGroupId { get; set; }
        public virtual BuildingGroup BuildingGroup { get; set; }
    }
}
