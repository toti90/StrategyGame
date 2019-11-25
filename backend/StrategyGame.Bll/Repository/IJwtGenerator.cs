using StrategyGame.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Bll.Repository
{
    public interface IJwtGenerator
    {
        string CreateToken(User user);
    }
}
