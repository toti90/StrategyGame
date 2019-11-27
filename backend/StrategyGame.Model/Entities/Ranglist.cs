using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Model.Entities
{
    public class Ranglist
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int Point { get; set; }
        public int Place { get; set; }
        public int RanglistCollectionId { get; set; }
        public RanglistCollection RanglistCollection { get; set; }
    }
}
