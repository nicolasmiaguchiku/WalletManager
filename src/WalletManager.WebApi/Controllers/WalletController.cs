using LiteBus.Queries.Abstractions;
using Microsoft.AspNetCore.Mvc;
using WalletManager.Application.UseCases.Queries.Wallet;

namespace WalletManager.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/wallet")]
    public class WalletController(IQueryMediator queryMediator) : ControllerBase
    {
        [HttpGet]
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