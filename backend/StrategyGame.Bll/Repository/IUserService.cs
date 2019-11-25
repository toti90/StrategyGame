using StrategyGame.Bll.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.Repository
{
    public interface IUserService
    {
        Task<UserDTO> LoginUser(string userName, string password);
    };
}
