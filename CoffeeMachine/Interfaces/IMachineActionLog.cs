using CoffeeMachine.Models;

namespace CoffeeMachine.Interfaces
{
    public interface IMachineActionLog
    {
        Task CreateLogAsync(MachineActionLog logEntry);
        Task<(IEnumerable<MachineActionLog>, int)> GetPaginatedLogsAsync(int pageNumber, int pageSize);
    }
}
