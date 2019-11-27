using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StrategyGame.Model.Entities
{
    public class Unit
    {
        public Unit()
        {
            Legions = new HashSet<Legion>();
        }
        public int UnitId { get; set; }
        [Required]
        public string UnitName { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Price { get; set; }
        public int Salary { get; set; }
        public int Food { get; set; }
        public int AddPoint { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<Legion> Legions { get; set; }
    }
}
