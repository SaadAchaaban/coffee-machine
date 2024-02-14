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

        public MachineActionLog(DateTime actionTime, string actionType)
        {
            ActionTime = actionTime;
            ActionType = actionType;
        }
    }
}
