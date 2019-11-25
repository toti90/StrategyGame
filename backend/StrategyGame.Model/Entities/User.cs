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
        }
        [Required]
        public string CountryName { get; set; }
        public int Place { get; set; }
        public virtual ICollection<BuildingGroup> BuildingGroups { get; set; }
    }
}
