using CoffeeMachine.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeMachine.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {

        }

        public DbSet<MachineActionLog> ActionLogs { get; set; }
     
    }
}
