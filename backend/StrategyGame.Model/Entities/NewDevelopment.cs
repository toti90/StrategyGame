using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Model.Entities
{
    public class NewDevelopment
    {
        public int NewDevelopmentId { get; set; }
        public int Round { get; set; }
        public int DevelopmentGroupId { get; set; }
        public virtual DevelopmentGroup DevelopmentGroup { get; set; }
    }
}
