using StrategyGame.Bll.DTOs;
using StrategyGame.Bll.Interfaces;
using StrategyGame.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.Services
{
    public class GameService : IGameService
    {
        private readonly AppDbContext _context;
        private readonly IUserAccessor _IUserAccessor;

        public GameService(AppDbContext context, IUserAccessor UserAccessor)
        {
            _context = context;
            _IUserAccessor = UserAccessor;
        }
        public Task<GameHomeScreenResponseDTO> getHomeScreen()
        {
            var game =  _context.Games.FirstOrDefault(p => p.inProgress);
            var user = _context.Users.FirstOrDefault(u => u.Id == _IUserAccessor.GetCurrentUserId());
            return null;
        }
    }
}
