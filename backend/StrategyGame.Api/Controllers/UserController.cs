using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StrategyGame.Bll.DTO;
using StrategyGame.Bll.Interfaces;
using StrategyGame.Model.Entities;

namespace StrategyGame.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _IUserService;

        public UserController(IUserService UserService)
        {
            _IUserService = UserService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {

            return Ok("value1");
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserLoginResponseDTO>> Login(UserLoginDTO userInput)
        {
            var user = await _IUserService.LoginUser(userInput.UserName, userInput.Password);

            return Ok(user);

        }


        [HttpPost("register")]
        public async Task<ActionResult<UserRegisterResponseDTO>> Register(UserRegisterDTO userInput)
        {
            var user = await _IUserService.RegisterUser(userInput.UserName, userInput.Password, userInput.confirmPassword, userInput.CountryName);

            return Ok(user);

        }
    }
}