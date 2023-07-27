using Common.Responses;
using Common.Responses.Wrappers;

namespace Application.Services
{
    public interface IReportService
    {
        Task<List<ReportResponse>> GetReportDataAsync();
    }
}
