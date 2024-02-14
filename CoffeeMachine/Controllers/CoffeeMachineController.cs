using CoffeeMachine.Interfaces;
using CoffeeMachine.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeMachine.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CoffeeMachineController : ControllerBase
    {
        private readonly ICoffeeMachine _coffeeMachine;

        public CoffeeMachineController(ICoffeeMachine coffeeMachine)
        {
            _coffeeMachine = coffeeMachine;
        }

        [HttpPost("TurnOn")]
        public async Task<ActionResult> TurnOn()
        {
            try
            {
                await _coffeeMachine.TurnOnAsync();
                return Ok("Coffee machine turned on successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to turn on the coffee machine.");
            }
        }

        [HttpPost("TurnOff")]
        public async Task<ActionResult> TurnOff()
        {
            try
            {
                await _coffeeMachine.TurnOffAsync();
                return Ok("Coffee machine turned off successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to turn off the coffee machine.");
            }
        }

        [HttpPost("MakeCoffee")]
        public async Task<ActionResult> MakeCoffee([FromBody] CoffeeCreationOptions options)
        {
            try
            {
                await _coffeeMachine.MakeCoffeeAsync(options);
                return Ok("Coffee made successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to make coffee.");
            }
        }

        [HttpGet("GetCurrentState")]
        public ActionResult GetCurrentState()
        {
            try
            {
                var currentMachineState = new CoffeeMachineState
                {
                    IsOn = _coffeeMachine.IsOn,
                    IsMakingCoffee = _coffeeMachine.IsMakingCoffee,
                    WaterLevelState = _coffeeMachine.WaterLevelState,
                    BeanFeedState = _coffeeMachine.BeanFeedState,
                    WasteCoffeeState = _coffeeMachine.WasteCoffeeState,
                    WaterTrayState = _coffeeMachine.WaterTrayState
                };

                return Ok(currentMachineState);
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to get the current state of the coffee machine.");
            }
        }

    }
}
