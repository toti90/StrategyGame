using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StrategyGame.Model.Entities
{
    public class Legion
    {
        public int LegionId { get; set; }
        public int Amount { get; set; }
        [Required]
        public string UserId { get; set; }
        public virtual User User { get; set; }
        [Required]
        public int UnitId { get; set; }
        public virtual Unit Unit { get; set; }

    }
}
