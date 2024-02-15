using CoffeeMachine.Data;
using CoffeeMachine.Interfaces;
using CoffeeMachine.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeMachine.Services
{
    public class StatisticsService : IStatistics
    {
        private readonly ApplicationDbContext _context;

        public StatisticsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Dictionary<string, DailyStatistics>> GetDailyStatisticsAsync()
        {
            var groupedData = await _context.ActionLogs
                .Where(log => log.ActionType == "MakeCoffee")
                .GroupBy(log => log.ActionTime.Date)
                .Select(group => new
                {
                    Date = group.Key,
                    FirstCupTime = group.Min(log => log.ActionTime),
                    LastCupTime = group.Max(log => log.ActionTime),
                    TotalCups = group.Count()
                })
                .ToListAsync();

            var statistics = groupedData.ToDictionary(
                keySelector: group => group.Date.ToString("dd/MM/yyyy"),
                elementSelector: group => new DailyStatistics
                {
                    FirstCupTime = group.FirstCupTime.ToString("HH:mm"),
                    LastCupTime = group.LastCupTime.ToString("HH:mm"),
                    AverageCups = group.TotalCups
                });

            return statistics;
        }


        public async Task<Dictionary<string, Dictionary<string, int>>> GetHourlyAverageCupsAsync()
        {
            var hourlyData = await _context.ActionLogs
                .Where(log => log.ActionType == "MakeCoffee")
                .GroupBy(log => new
                {
                    log.ActionTime.Date,
                    Hour = log.ActionTime.Hour
                })
                .Select(group => new
                {
                    Date = group.Key.Date,
                    HourRange = $"{group.Key.Hour:00}-{group.Key.Hour + 1:00}",
                    CupsCount = group.Count()
                })
                .ToListAsync();

            var formattedResults = hourlyData
                .GroupBy(item => item.Date)
                .ToDictionary(
                    group => group.Key.ToString("dd/MM/yyyy"),
                    group => group.ToDictionary(
                        item => item.HourRange,
                        item => item.CupsCount));

            return formattedResults;
        }

    }
}
