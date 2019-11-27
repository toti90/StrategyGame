using StrategyGame.Bll.DTOs;
using StrategyGame.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.Interfaces
{
    public interface IGameService
    {
        Task<GameHomeScreenResponseDTO> GetHomeScreen();
        double CalculateCorall(User user);
        double CalculatePearl(User user);
    }
}
