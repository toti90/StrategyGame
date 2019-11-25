using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StrategyGame.Bll.DTO;
using StrategyGame.Bll.Repository;
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
        public async Task<ActionResult<UserDTO>> Login(UserDTO userInput)
        {
            UserDTO user;
            try
            {
                user = await _IUserService.LoginUser(userInput.UserName, userInput.Password);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
            if (user == null)
            {
                return NotFound("wrong username and/or password");
            } else
            {
                return Ok(user);
            }

        }
    }
}