using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.Interfaces
{
    public interface IRanglistService
    {
        Task CreateNewRanglist();

        Task GetCurrentRanglist();
    }
}
