using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StrategyGame.Bll.DTO;
using StrategyGame.Bll.Repository;
using StrategyGame.Dal;
using StrategyGame.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly AppDbContext _context;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, IJwtGenerator jwtGenerator, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _JwtGenerator = jwtGenerator;
            _context = context;
        }

        public async Task<UserLoginResponseDTO> LoginUser(string userName, string password)
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
                var responseUser = new UserLoginResponseDTO {
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

        public async Task<UserRegisterResponseDTO> RegisterUser(string userName, string password, string confirmPassword, string countryName)
        {
            if (await _context.Users.Where(user => user.UserName == userName).AnyAsync())
            {
                throw new Exception("username has already been taken");
            }
            if (await _context.Users.Where(user => user.CountryName == countryName).AnyAsync())
            {
                throw new Exception("country name has already been taken");
            }
            var user = new User
            {
                UserName = userName,
                CountryName = countryName
            };

            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                var newUser = _context.Users.FirstOrDefault(user => user.UserName == userName);
                var responseUser = new UserRegisterResponseDTO
                {
                    UserId = newUser.Id,
                    Token = _JwtGenerator.CreateToken(newUser)
                };
                return responseUser;
            } else
            {
                throw new Exception("something went wrong");
            }
            
        }
    }
}
