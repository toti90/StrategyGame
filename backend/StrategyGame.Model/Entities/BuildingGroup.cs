using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Model.Entities
{
    public class BuildingGroup
    {
        public int BuildingGroupId { get; set; }
        public int Amount { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public int BuildingId { get; set; }
        public virtual Building Building { get; set; }

    }
}
