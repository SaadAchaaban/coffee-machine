using CoffeeMachine.Enums;
using CoffeeMachine.Interfaces;
using CoffeeMachine.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoffeeMachine.Services
{
    public class CoffeeMachineStub : ICoffeeMachine
    {
        public bool IsOn { get; private set; }
        public bool IsMakingCoffee { get; private set; }
        public State WaterLevelState { get; private set; }
        public State BeanFeedState { get; private set; }
        public State WasteCoffeeState { get; private set; }
        public State WaterTrayState { get; private set; }
        private bool IsInAlertState => WaterLevelState == State.Alert
        || BeanFeedState == State.Alert
        || WasteCoffeeState == State.Alert
       || WaterTrayState == State.Alert;

        private readonly Random _randomStateGenerator;
        private readonly IServiceProvider _serviceProvider;

        public CoffeeMachineStub(IServiceProvider serviceProvider)
        {
            _randomStateGenerator = new Random();
            _serviceProvider = serviceProvider;
        }

        public async Task TurnOnAsync()
        {
            if (IsOn)
                throw new InvalidOperationException("Invalid state");
            // Generate sample state for testing
            WaterLevelState = GetRandomState();
            BeanFeedState = GetRandomState();
            WasteCoffeeState = GetRandomState();
            WaterTrayState = GetRandomState();

            // [Machine turned on]
            IsOn = true;
            await LogActionAsync("TurnOn");
        }

        public async Task TurnOffAsync()
        {
            if (!IsOn || IsMakingCoffee)
                throw new InvalidOperationException("Invalid state");
            // [Machine turned off]
            IsOn = false;
            await LogActionAsync("TurnOff");
        }

        public async Task MakeCoffeeAsync(CoffeeCreationOptions options)
        {
            if (!IsOn || IsMakingCoffee || IsInAlertState)
                throw new InvalidOperationException("Invalid state");
            IsMakingCoffee = true;
            // [Make the coffee]
            Thread.Sleep(10000);
            await LogActionAsync("MakeCoffee");
            IsMakingCoffee = false;
        }

        // Randomly create a state for testing. This can be replaced as required.
        private State GetRandomState() => _randomStateGenerator.Next(1, 11) == 10 ? State.Alert : State.Okay;

        private async Task LogActionAsync(string actionType)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var logService = scope.ServiceProvider.GetRequiredService<IMachineActionLog>();
                await logService.CreateLogAsync(new MachineActionLog(actionType));
            }
        }
    }
}
