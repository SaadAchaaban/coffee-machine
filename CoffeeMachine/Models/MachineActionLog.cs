using System.ComponentModel.DataAnnotations;

namespace CoffeeMachine.Models
{
    public class MachineActionLog
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime ActionTime { get; set; }
        [Required]
        public string ActionType { get; set; }

        public MachineActionLog(string actionType)
        {
            ActionTime = DateTime.Now;
            ActionType = actionType;
        }
    }
}
