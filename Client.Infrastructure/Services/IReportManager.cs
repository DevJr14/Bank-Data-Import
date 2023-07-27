using Common.Responses;
using Common.Responses.Wrappers;

namespace Client.Infrastructure.Services
{
    public interface IReportManager : IManager
    {
        Task<IBankResponse<List<ReportResponse>>> GetAccountsTransactionsSummariesAsync();
    }
}
