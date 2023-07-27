using Common.Requests;
using MudBlazor;

namespace BankApp.Pages
{
    public partial class Uploader
    {
        private async Task InvokeCsvUploaderDialog()
        {
            var parameters = new DialogParameters();

            parameters.Add(nameof(ImportFile.CsvUploadRequest), new CsvImportRequest
            {
                FilePath = string.Empty,
                UploadRequest = new()
            });

            var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true, DisableBackdropClick = true };
            var dialog = _dialogService.Show<ImportFile>("Import Csv Data", parameters, options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                _navigation.NavigateTo("/accounts");
            }
        }
    }
}
