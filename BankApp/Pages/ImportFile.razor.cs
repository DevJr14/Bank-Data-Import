using Common.Requests;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace BankApp.Pages
{
    public partial class ImportFile
    {
        [Parameter]
        public CsvImportRequest CsvUploadRequest { get; set; } = new();
        [CascadingParameter] 
        private MudDialogInstance MudDialog { get; set; } = default!;
        MudForm form = default!;

        private IBrowserFile _file = default!;

        private async Task ConfirmImport()
        {
            string confirmationMessage = $"Are you sure you want to import file: {_file.Name}";
            var parameters = new DialogParameters
            {
                { nameof(ImportConfirmation.ContentText), confirmationMessage }
            };
            var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true, DisableBackdropClick = true };
            var dialog = _dialogService.Show<ImportConfirmation>("Import", parameters, options);
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                await SaveAsync();
            }
        }

        private async Task SaveAsync()
        {
            var response = await _importManager.CsvImportAsync(CsvUploadRequest);
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

        private async Task UploadFile(InputFileChangeEventArgs e)
        {
            _file = e.File;
            if (_file != null)
            {
                var buffer = new byte[_file.Size];
                var extension = Path.GetExtension(_file.Name);
                var format = "application/octet-stream";
                await _file.OpenReadStream(_file.Size).ReadAsync(buffer);
                CsvUploadRequest.FilePath = $"data:{format};base64,{Convert.ToBase64String(buffer)}";
                CsvUploadRequest.UploadRequest = new UploadRequest { Data = buffer, UploadType = UploadType.Document, Extension = extension, FileName = _file.Name };
            }
        }

        public void Cancel()
        {
            MudDialog.Cancel();
        }
    }
}
