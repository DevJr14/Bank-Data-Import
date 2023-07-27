using Application.Helpers;
using Application.Services;
using Common.Responses;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class ReportService : IReportService
    {
        private readonly ApplicationDbContext _context;

        public ReportService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ReportResponse>> GetReportDataAsync()
        {
            var reportData = await _context.Transactions
                .Include(trans => trans.Account)
                .GroupBy(trans => new { trans.Account.BranchCode, trans.Account.AccountType, trans.Status })
                .Select(grp => new ReportResponse
                {
                    BranchCode = grp.Key.BranchCode,
                    AccountType = grp.Key.AccountType,
                    Status = ReportHelper.SetStatus(grp.Key.Status),
                    TotalAmount = grp.Sum(trans => trans.Amount),
                    TransactionsCount = grp.Count()
                })
                .ToListAsync();

            return reportData;
        }
    }
}
