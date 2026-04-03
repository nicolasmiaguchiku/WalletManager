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
        [HttpPost]
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