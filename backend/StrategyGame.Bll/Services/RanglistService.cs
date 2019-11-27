using Microsoft.EntityFrameworkCore;
using StrategyGame.Bll.Interfaces;
using StrategyGame.Dal;
using StrategyGame.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.Services
{
    public class RanglistService : IRanglistService
    {
        private readonly AppDbContext _context;

        public RanglistService(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateNewRanglist()
        {
            var currentGame = await _context.Games.FirstOrDefaultAsync(g => g.inProgress == true);
            var newRanglistCollection = new RanglistCollection
            {
                Game = currentGame,
                Round = currentGame.Round + 1
            };
            _context.RanglistCollections.Add(newRanglistCollection);
            await _context.SaveChangesAsync();
            var users = await _context.Users.Include(u => u.BuildingGroups).Include(u => u.DevelopmentGroups).Include(u => u.Legions).ToListAsync();
            foreach (var user in users)
            {
                var buildingsGivePeople = await _context.Buildings.Where(b => b.AddPeople.HasValue).ToListAsync();
                var pointsFromPeople = _context.BuildingGroups.Where(bg => buildingsGivePeople.Any(bgp => bgp.BuildingId == bg.BuildingId) && bg.UserId == user.Id)
                    .ToList()
                    .Aggregate(0, (x,y) => x + y.Amount * y.Building.AddPeople.Value);

                var pointFromBuildings = _context.BuildingGroups.Where(bg => bg.UserId == user.Id)
                    .ToList()
                    .Aggregate(0, (x, y) => x + y.Amount * 5);

                var pointsFromDevelopment = _context.DevelopmentGroups.Where(dg => dg.UserId == user.Id)
                    .ToList()
                    .Aggregate(0, (x, y) => x + y.Amount * 100);
            }
            
        }

        public async Task GetCurrentRanglist()
        {
            var currentGame = await _context.Games.FirstOrDefaultAsync(g => g.inProgress == true);
            var currentRanglistCollection = await _context.RanglistCollections.Where(r => r.GameId == currentGame.GameId && r.Round == currentGame.Round).ToListAsync();
        }
    }
}
