using CoffeeMachine.Data;
using CoffeeMachine.Interfaces;
using CoffeeMachine.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeMachine.Services
{
    public class MachineActionLogService : IMachineActionLog
    {
        private readonly ApplicationDbContext _context;

        public MachineActionLogService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateLogAsync(MachineActionLog logEntry)
        {
            _context.ActionLogs.Add(logEntry);
            await _context.SaveChangesAsync();
        }

        public async Task<(IEnumerable<MachineActionLog>, int)> GetPaginatedLogsAsync(int pageNumber, int pageSize)
        {
            var totalLogsCount = await _context.ActionLogs.CountAsync();

            var logs = await _context.ActionLogs
                .OrderByDescending(log => log.ActionTime)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (logs, totalLogsCount);
        }
    }

}
