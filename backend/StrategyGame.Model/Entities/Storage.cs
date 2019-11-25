using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StrategyGame.Model.Entities
{
    public class Storage
    {
        [Key]
        public int StroageId { get; set; }
        public int Pearl { get; set; }
        public int Coral { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
