using CoffeeMachine.Enums;

namespace CoffeeMachine.Models
{
    public class CoffeeMachineState
    {
        public bool IsOn { get; set; }
        public bool IsMakingCoffee { get; set; }
        public State WaterLevelState { get; set; }
        public State BeanFeedState { get; set; }
        public State WasteCoffeeState { get; set; }
        public State WaterTrayState { get; set; }
    }
}
