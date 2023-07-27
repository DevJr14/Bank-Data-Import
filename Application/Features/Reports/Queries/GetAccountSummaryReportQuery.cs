using Application.Services;
using Common.Responses;
using Common.Responses.Wrappers;
using MediatR;

namespace Application.Features.Reports.Queries
{
    public class GetAccountSummaryReportQuery : IRequest<IBankResponse<List<ReportResponse>>>
    {
    }

    public class GetAccountSummaryReportQueryHandler : IRequestHandler<GetAccountSummaryReportQuery, IBankResponse<List<ReportResponse>>>
    {
        private readonly IReportService _reportService;

        public GetAccountSummaryReportQueryHandler(IReportService reportService)
        {
            _reportService = reportService;
        }

        public async Task<IBankResponse<List<ReportResponse>>> Handle(GetAccountSummaryReportQuery request, CancellationToken cancellationToken)
        {
            var reportData = await _reportService.GetReportDataAsync();

            if (reportData is not null && reportData.Count > 0)
            {
                return await BankResponse<List<ReportResponse>>.SuccessAsync(reportData);
            }
            return await BankResponse<List<ReportResponse>>.FailAsync("No data to report on.");
        }
    }
}
