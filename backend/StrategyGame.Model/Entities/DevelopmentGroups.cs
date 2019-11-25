using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Model.Entities
{
    public class DevelopmentGroup
    {
        public int DevelopmentGroupId { get; set; }
        public int Amount { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public int DevelopmentId { get; set; }
        public virtual Development Development { get; set; }
    }
}
