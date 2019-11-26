using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Model.Entities
{
    public class Game
    {
        public int GameId { get; set; }
        public int Round { get; set; }
        public bool inProgress { get; set; }
    }
}
