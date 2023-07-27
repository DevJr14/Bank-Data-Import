using Common.Responses;
using MudBlazor;

namespace BankApp.Pages
{
    public partial class AccountsTransactionsSummaries
    {
        public List<ReportResponse> Summaries { get; set; } = new();

        private bool _isLoading = false;

        protected override async Task OnInitializedAsync()
        {
            _isLoading = true;
            await LoadReportSummaries();
        }

        private async Task LoadReportSummaries()
        {
            var response = await _reportManager.GetAccountsTransactionsSummariesAsync();
            if (response.IsSuccessful)
            {
                Summaries = response.Data;
            }
            else
            {
                foreach (var message in response.Messages)
                {
                    _snackBar.Add(message, Severity.Error);
                }
            }
            _isLoading = false;
        }
    }
}
