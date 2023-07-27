using Common.Requests;

namespace Application.Services
{
    public interface IImportService
    {
        Task<bool> ImportCsvDataAsync(UploadRequest request);
    }
}
