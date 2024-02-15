using CoffeeMachine.Interfaces;
using CoffeeMachine.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeMachine.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatistics _statisticsService;

        public StatisticsController(IStatistics statisticsService)
        {
            _statisticsService = statisticsService;
        }

        [HttpGet("Daily")]
        public async Task<ActionResult<Dictionary<string, DailyStatistics>>> GetDailyStatistics()
        {
            var stats = await _statisticsService.GetDailyStatisticsAsync();
            return Ok(stats);
        }

        [HttpGet("Hourly")]
        public async Task<ActionResult<Dictionary<string, int>>> GetHourlyAverageCups()
        {
            var stats = await _statisticsService.GetHourlyAverageCupsAsync();
            return Ok(stats);
        }
    }
}
