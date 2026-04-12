using LiteBus.Commands.Abstractions;
using Microsoft.AspNetCore.Mvc;
using WalletManager.Application.Requests;
using WalletManager.Application.UseCases.Commands.Customer;

namespace WalletManager.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/customer")]
    public class CustomerController(ICommandMediator commandMediator) : ControllerBase
    {
        /// <summary>
        ///     Create a customer account with the provided details and returns the ID of the created customer.
        /// </summary>
        /// <param name="request">The request object containing customer details.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Id of customer created</returns>
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

        /// <summary>
        ///     Authenticates a user with the provided credentials and returns a result indicating success or failure.
        /// </summary>
        /// <param name="request">The login request containing user credentials to be authenticated. Cannot be null.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the login operation.</param>
        /// <returns>An IActionResult containing the authentication result. Returns 200 OK with access token if authentication
        /// succeeds; 400 Bad Request with error details if authentication fails; or 500 Internal Server Error for
        /// unexpected failures.</returns>
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login([FromBody] LoginRequest request, CancellationToken cancellationToken)
        {
            var result = await commandMediator.SendAsync(new LoginCommand(request), cancellationToken);

            if (result.IsFaiulure)
            {
                return BadRequest(result.Error);
            }
            return Ok(result.Data);
        }
    }
}