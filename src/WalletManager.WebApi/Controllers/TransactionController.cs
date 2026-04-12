using LiteBus.Commands.Abstractions;
using Microsoft.AspNetCore.Mvc;
using WalletManager.Application.Requests;
using WalletManager.Application.UseCases.Commands.Transaction;

namespace WalletManager.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/transaction")]
    public class TransactionController(ICommandMediator commandMediator) : ControllerBase
    {
        /// <summary>
        ///     Add transaction to logged-in customer's wallet.
        /// </summary>
        /// <param name="Request">The request object containing transaction details.</param>
        /// <param name="WalletId">The ID of the wallet to which the transaction will be added.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Transaction ID added to wallet.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddTransactionAsync([FromBody] AddTransactionRequest Request, [FromQuery] Guid WalletId, CancellationToken cancellationToken)
        {
            var result = await commandMediator.SendAsync(new AddTransactionCommand(Request, WalletId), cancellationToken);

            if (result.IsFaiulure)
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Data);
        }
    }
}