using Common.Responses;
using MudBlazor;
using static MudBlazor.CategoryTypes;

namespace BankApp.Pages
{
    public partial class AccountList
    {
        public List<AccountResponse> Accounts { get; set; } = new();

        private AccountResponse _selectedAccount = null;
        private string _searchText = string.Empty;
        private bool _isLoading = false;

        protected override async Task OnInitializedAsync()
        {
            _isLoading = true;
            await LoadAccounts();
            _isLoading = false;
        }

        private async Task LoadAccounts()
        {
            var response = await _accountManager.GetAllAsync();
            if (response.IsSuccessful)
            {
                Accounts = response.Data;
            }
            else
            {
                foreach (var message in response.Messages)
                {
                    _snackBar.Add(message, Severity.Error);
                }
            }
        }

        private void ViewTransactions(string accountNumber)
        {
            _navigation.NavigateTo($"transactions/{accountNumber}");
        }

        private async Task InvokeUpdateAccountDialog(AccountResponse account)
        {
            var parameters = new DialogParameters()
            {
                { nameof(AccountUpdate.Account), account }
            };

            var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.ExtraSmall, FullWidth = true, DisableBackdropClick = true };
            var dialog = _dialogService.Show<AccountUpdate>("Update Account", parameters, options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                await LoadAccounts();
            }
        }

        private bool SearchFunc(AccountResponse account)
        {
            if (string.IsNullOrWhiteSpace(_searchText))
                return true;
            if (account.AccountHolder.Contains(_searchText, StringComparison.OrdinalIgnoreCase))
                return true;
            if (account.BranchCode.Contains(_searchText, StringComparison.OrdinalIgnoreCase))
                return true;
            if (account.AccountNumber.Contains(_searchText, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }
    }
}
