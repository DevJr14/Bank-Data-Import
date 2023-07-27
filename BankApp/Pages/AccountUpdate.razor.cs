using Common.Responses;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BankApp.Pages
{
    public partial class AccountUpdate
    {
        [Parameter]
        public AccountResponse Account { get; set; } = new();
        [CascadingParameter]
        private MudDialogInstance MudDialog { get; set; } = default!;
        MudForm form = default!;

        private async Task UpdateAccountAsync()
        {
            var response = await _accountManager.UpdateAccountAsync(Account.AccountType, Account.AccountId);
            if (response.IsSuccessful) 
            {
                _snackBar.Add(response.Messages[0], Severity.Success);
                MudDialog.Close();
            }
            else
            {
                foreach (var message in response.Messages)
                {
                    _snackBar.Add(message, Severity.Error);
                }
            }
        }
        public void Cancel()
        {
            MudDialog.Cancel();
        }
    }

}
