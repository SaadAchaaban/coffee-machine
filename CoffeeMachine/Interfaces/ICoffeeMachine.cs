using CoffeeMachine.Enums;
using CoffeeMachine.Models;

namespace CoffeeMachine.Interfaces
{
    public interface ICoffeeMachine
    {
        bool IsOn { get; }
        bool IsMakingCoffee { get; }
        State WaterLevelState { get; }
        State BeanFeedState { get; }
        State WasteCoffeeState { get; }
        State WaterTrayState { get; }

        Task TurnOnAsync();
        Task TurnOffAsync();

        Task MakeCoffeeAsync(CoffeeCreationOptions options);
    }
}
