using Common.Responses;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BankApp.Pages
{
    public partial class TransactionList
    {
        [Parameter]
        public string AccountNumber { get; set; }
        public List<TransactionResponse> Transactions { get; set; } = new();
        public AccountResponse Account { get; set; } = new();
        private string _searchText = string.Empty;
        private bool _isLoading = false;


        protected override async Task OnInitializedAsync()
        {
            _isLoading = true;
            await LoadTransactions();
            await LoadAccount();
            _isLoading = false;
        }

        private async Task LoadTransactions()
        {
            var response = await _transactionManager.GetAccountTransactionsAsync(AccountNumber);
            if (response.IsSuccessful)
            {
                Transactions = response.Data;
            }
            else
            {
                foreach (var message in response.Messages)
                {
                    _snackBar.Add(message, Severity.Error);
                }
            }
        }

        private async Task LoadAccount()
        {
            var response = await _accountManager.GetByIdAsync(Transactions.First().AccountId);
            if (response.IsSuccessful)
            {
                Account = response.Data;
            }
            else
            {
                foreach (var message in response.Messages)
                {
                    _snackBar.Add(message, Severity.Error);
                }
            }
        }

        private static Color SetColor(string teimeBreach)
        {
            return teimeBreach switch
            {
                "Yes" => Color.Warning,
                "No" => Color.Success,
                _ => Color.Default,
            };
        }
    }
}
