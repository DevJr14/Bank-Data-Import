using Application.Features.Accounts.Commands;
using Application.Features.Accounts.Queries;
using Common;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class AccountsController : BaseController<AccountsController>
    {
        [HttpGet("all")]
        public async Task<IActionResult> GetAccounts()
        {
            var response = await Sender.Send(new GetAllAccountsQuery());
            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("{accountId}")]
        public async Task<IActionResult> GetAccountById(int accountId)
        {
            var response = await Sender.Send(new GetAccountByIdQuery() { AccountId = accountId });
            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("{accountId}")]
        public async Task<IActionResult> UpdateAccount([FromBody] AccountType accountType, int accountId)
        {
            var response = await Sender.Send(new UpdateAccountCommand() { AccountType = accountType, AccountId = accountId });
            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
