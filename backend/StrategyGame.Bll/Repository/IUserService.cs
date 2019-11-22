using StrategyGame.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.Repository
{
    public interface IUserService
    {
        Task<User> LoginUser(string userName, string password);
    };
}
