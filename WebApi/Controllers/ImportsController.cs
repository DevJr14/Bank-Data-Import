using Application.Features.Imports.Commands;
using Common.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ImportsController : BaseController<ImportsController>
    {
        [HttpPost]
        public async Task<IActionResult> ImportCsvData([FromBody] CsvImportRequest csvImportRequest)
        {
            var response = await Sender.Send(new ImportCsvDataCommand() {CsvImportRequest = csvImportRequest});
            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
