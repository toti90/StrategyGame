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
    public class DevelopmentsController : ControllerBase
    {
        private IDevelopmentsService _IDevelopmentsService;

        public DevelopmentsController(IDevelopmentsService developmentsService)
        {
            _IDevelopmentsService = developmentsService;
        }

        [HttpGet]
        [Authorize]
        public ActionResult<DevelopmentsResponseDTO> getAllBuildings()
        {
            var response = _IDevelopmentsService.GetAllDevelopment();

            return Ok(response);

        }
    }
}