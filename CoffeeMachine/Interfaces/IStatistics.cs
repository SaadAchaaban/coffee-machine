using CoffeeMachine.Models;

namespace CoffeeMachine.Interfaces
{
    public interface IStatistics
    {
        Task<Dictionary<string, DailyStatistics>> GetDailyStatisticsAsync();
        Task<Dictionary<string, Dictionary<string, int>>> GetHourlyAverageCupsAsync();
    }
}
