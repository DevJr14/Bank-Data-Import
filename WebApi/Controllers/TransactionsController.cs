using Application.Features.Transactions.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class TransactionsController : BaseController<TransactionsController>
    {
        [HttpGet("{accountNumber}")]
        public async Task<IActionResult> GetAccountTransactions(string accountNumber)
        {
            var response = await Sender.Send(new GetTransactionsOnAccountQuery() { AccountNumber = accountNumber });
            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }
    }
}
