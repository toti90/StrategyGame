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
        public async Task<ActionResult<IEnumerable<BuildingDTO>>> getAllBuildings()
        {
            var response = await _IBuildingsService.GetAllBuildings();

            return Ok(response);

        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> addNewBuilding(addnewBuildingRequestDTO building)
        {
            var response = await _IBuildingsService.AddNewBuilding(building.buildingId);

            return Ok();

        }
    }
}