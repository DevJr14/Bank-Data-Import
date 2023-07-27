using Common.Requests;
using Common.Responses.Wrappers;

namespace Client.Infrastructure.Services
{
    public interface IImportManager : IManager
    {
        Task<IBankResponse<bool>> CsvImportAsync(CsvImportRequest csvImportRequest);
    }
}
