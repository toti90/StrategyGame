using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StrategyGame.Model.Entities
{
    public class FightGroup
    {
        public int FightGroupId { get; set; }
        public double PartOfLegion { get; set; }
        [Required]
        public string AttackedUserId { get; set; }
        public virtual User AttackedUser { get; set; }
        [Required]
        public string OwnerUserId { get; set; }
        public virtual User OwnerUser { get; set; }
        public int LegionId { get; set; }
        public virtual Legion Legion { get; set; }
    }
}
