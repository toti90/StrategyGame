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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
