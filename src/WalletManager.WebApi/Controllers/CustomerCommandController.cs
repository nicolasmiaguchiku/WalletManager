using LiteBus.Commands.Abstractions;
using Microsoft.AspNetCore.Mvc;
using WalletManager.Application.Requests;
using WalletManager.Application.UseCases.Commands.Customer;

namespace WalletManager.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/customer")]
    public class CustomerCommandController(ICommandMediator commandMediator) : ControllerBase
    {
        [HttpPost("create-account")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountCustomerRequest request, CancellationToken cancellationToken)
        {
            var result = await commandMediator.SendAsync(new CreateAccountCustomerCommand(request), cancellationToken);

            if (result.IsFaiulure)
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Data);
        }
    }
}