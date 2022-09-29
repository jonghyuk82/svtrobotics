using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SVTRobotics.API.Models;
using SVTRobotics.API.Services.IServices;

namespace SVTRobotics.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RobotsController : ControllerBase
    {
        private readonly IRobotService _robotService;
        public RobotsController(IRobotService robotService)
        {
            _robotService = robotService;
        }

        [HttpPost("closest")]
        public async Task<IActionResult> GetClosestRobot(LoadCoordinate payload)
        {
            ClosestRobot closestRobot = new ClosestRobot();

            closestRobot = await _robotService.getClosestRobot(payload);

            return Ok(closestRobot);
        }
    }
}