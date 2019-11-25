using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace StrategyGame.Model.Entities
{
    public class User : IdentityUser
    {
        public User()
        {
            BuildingGroups = new HashSet<BuildingGroup>();
            DevelopmentGroups = new HashSet<DevelopmentGroup>();
            Legions = new HashSet<Legion>();
        }
        [Required]
        public string CountryName { get; set; }
        public int Place { get; set; }
        public virtual ICollection<BuildingGroup> BuildingGroups { get; set; }
        public virtual ICollection<DevelopmentGroup> DevelopmentGroups { get; set; }
        public virtual ICollection<Legion> Legions { get; set; }
    }
}
