using Application.Features.Reports.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ReportsController : BaseController<ReportsController>
    {
        [HttpGet]
        public async Task<IActionResult> GenerateAccountsTransactionsSummary()
        {
            var response = await Sender.Send(new GetAccountSummaryReportQuery());
            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
