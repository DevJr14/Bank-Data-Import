using Application.Services;
using Common.Requests;
using Common.Responses.Wrappers;
using MediatR;

namespace Application.Features.Imports.Commands
{
    public class ImportCsvDataCommand : IRequest<IBankResponse<bool>>
    {
        public CsvImportRequest CsvImportRequest { get; set; }
    }

    public class ImportCsvDataCommandHandler : IRequestHandler<ImportCsvDataCommand, IBankResponse<bool>>
    {
        private readonly IImportService _importService;

        public ImportCsvDataCommandHandler(IImportService importService)
        {
            _importService = importService;
        }

        public async Task<IBankResponse<bool>> Handle(ImportCsvDataCommand request, CancellationToken cancellationToken)
        {
            if (request.CsvImportRequest.UploadRequest is not null)
            {
                var isImportSuccesful = await _importService.ImportCsvDataAsync(request.CsvImportRequest.UploadRequest);
                if (isImportSuccesful)
                {
                    return await BankResponse<bool>.SuccessAsync("Import was successful.");
                }
                return await BankResponse<bool>.FailAsync("Data import failed.");
            }
            return await BankResponse<bool>.FailAsync("No Data was found to import.");
        }
    }
}
