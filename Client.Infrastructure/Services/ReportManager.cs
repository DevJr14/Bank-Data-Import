using Client.Infrastructure.Endpoints;
using Common.Responses;
using Common.Responses.Wrappers;

namespace Client.Infrastructure.Services
{
    public class ReportManager : IReportManager
    {
        private readonly HttpClient _httpClient;

        public ReportManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IBankResponse<List<ReportResponse>>> GetAccountsTransactionsSummariesAsync()
        {
            var response = await _httpClient.GetAsync(ReportEndpoints.GetAccountsTransactionsSummaries);
            return await response.ToBankRespnseAsync<List<ReportResponse>>();
        }
    }
}
