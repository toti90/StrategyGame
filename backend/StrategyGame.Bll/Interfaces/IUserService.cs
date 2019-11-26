using StrategyGame.Bll.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.Interfaces
{
    public interface IUserService
    {
        Task<UserLoginResponseDTO> LoginUser(string userName, string password);
        Task<UserRegisterResponseDTO> RegisterUser(string userName, string password, string confirmPassword, string countryName);

    };
}
