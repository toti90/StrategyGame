using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StrategyGame.Bll.DTOs;
using StrategyGame.Bll.Interfaces;

namespace StrategyGame.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {

        private IGameService _IGameService;

        public GameController(IGameService GameService)
        {
            _IGameService = GameService;
        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<GameHomeScreenResponseDTO>> GetHomeScreen()
        {
            var response = await _IGameService.GetHomeScreen();

            return Ok(response);

        }
    }
}