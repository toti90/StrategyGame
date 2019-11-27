using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Model.Entities
{
    public class RanglistCollection
    {
        public int RanglistCollectionId { get; set; }
        public int GameId { get; set; }
        public int Round { get; set; }
        public virtual Game Game { get; set; }
    }
}
