using CoffeeMachine.Models;

namespace CoffeeMachine.Interfaces
{
    public interface IStatisticsService
    {
        Task<Dictionary<string, DailyStatistics>> GetDailyStatisticsAsync();
        Task<Dictionary<string, Dictionary<string, int>>> GetHourlyAverageCupsAsync();
    }
}
