using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StrategyGame.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Dal
{
    public class AppDbContext : IdentityDbContext<User>
    {

        public AppDbContext(DbContextOptions option) : base(option)
        {
        }

        public DbSet<Storage> Storages { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<BuildingGroup> BuildingGroups { get; set; }
        public DbSet<NewBuilding> NewBuildings { get; set; }
        public DbSet<Development> Developments { get; set; }
        public DbSet<DevelopmentGroup> DevelopmentGroups { get; set; }
        public DbSet<NewDevelopment> NewDevelopments { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Legion> Legions { get; set; }
        public DbSet<FightGroup> FightGroups { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<RanglistCollection> RanglistCollections { get; set; }
        public DbSet<Ranglist> Ranglists { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Storage>().Property(p => p.Coral).HasDefaultValue(100);
            builder.Entity<Storage>().Property(p => p.Pearl).HasDefaultValue(100);
            builder.Entity<BuildingGroup>().Property(p => p.Amount).HasDefaultValue(0);
            builder.Entity<NewBuilding>().Property(p => p.Round).HasDefaultValue(1);
            builder.Entity<DevelopmentGroup>().Property(p => p.Amount).HasDefaultValue(0);
            builder.Entity<NewDevelopment>().Property(p => p.Round).HasDefaultValue(1);
            builder.Entity<Game>().Property(p => p.inProgress).HasDefaultValue(true);
            builder.Entity<Ranglist>().HasNoKey();
        }

    }
}
