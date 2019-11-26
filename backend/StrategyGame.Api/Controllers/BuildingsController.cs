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
    public class BuildingsController : ControllerBase
    {

        private IBuildingsService _IBuildingsService;

        public BuildingsController(IBuildingsService BuildingsService)
        {
            _IBuildingsService = BuildingsService;
        }

        [HttpGet]
        [Authorize]
        public ActionResult<BuildingsResponseDTO> getAllBuildings()
        {
            var response = _IBuildingsService.getAllBuildings();

            return Ok(response);

        }
    }
}