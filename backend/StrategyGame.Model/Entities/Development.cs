using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StrategyGame.Model.Entities
{
    public class Development
    {
        public Development()
        {
            DevelopmentGroups = new HashSet<DevelopmentGroup>();
        }
        public int DevelopmentId { get; set; }
        [Required]
        public string DevelopmentName { get; set; }
        public double? AddCorall { get; set; }
        public double? AddDefense { get; set; }
        public double? AddAttack { get; set; }
        public double? AddTax { get; set; }
        public string ImageUrl { get; set; }
        public virtual ICollection<DevelopmentGroup> DevelopmentGroups { get; set; }
    }
}
