using LiteBus.Queries.Abstractions;
using Microsoft.AspNetCore.Mvc;
using WalletManager.Application.UseCases.Queries.Wallet;

namespace WalletManager.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/wallet")]
    public class WalletController(IQueryMediator queryMediator) : ControllerBase
    {
        /// <summary>
        ///     Get logged-in customer's wallet
        /// </summary>
        /// <param name="CustomerId">The ID of the customer whose wallet is to be returned.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The wallet details of the logged-in customer.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetWalletAsync([FromQuery] Guid CustomerId, CancellationToken cancellationToken)
        {
            var result = await queryMediator.QueryAsync(new GetWalletQuery(CustomerId), cancellationToken);

            if (result.IsFaiulure)
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Data);
        }
    }
}