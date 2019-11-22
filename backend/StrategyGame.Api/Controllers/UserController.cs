using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<User>> Login([FromBody]UserDTO userInput)
        {

            var user = await _IUserService.LoginUser(userInput.userName, userInput.password);
            if (user == null)
            {
                return NotFound();
            } else
            {
                return Ok(user);
            }

        }
    }

    public class UserDTO
    {
        public string userName { get; set; }

        public string password { get; set; }
    }
}