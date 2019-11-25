using Microsoft.AspNetCore.Identity;
using StrategyGame.Bll.DTO;
using StrategyGame.Bll.Repository;
using StrategyGame.Model.Entities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.Services
{
    public class UserService: IUserService
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IJwtGenerator _JwtGenerator;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, IJwtGenerator jwtGenerator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _JwtGenerator = jwtGenerator;
        }

        public async Task<UserDTO> LoginUser(string userName, string password)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                return null;
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);

            if (result.Succeeded)
            {
                //TODO: generate Token
                var responseUser = new UserDTO { 
                    UserName = user.UserName, 
                    UserId = user.Id,
                    Token = _JwtGenerator.CreateToken(user),
                };
                return responseUser;
            }
            else if (!result.Succeeded)
            {
                return null;
            }
            else
            {
                throw new Exception("something went wrong, please try again later");
            }
        }
    }
}
