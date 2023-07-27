using Client.Infrastructure.Endpoints;
using Common.Requests;
using Common.Responses.Wrappers;
using System.Net.Http.Json;

namespace Client.Infrastructure.Services
{
    public class ImportManager : IImportManager
    {
        private readonly HttpClient _httpClient;

        public ImportManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IBankResponse<bool>> CsvImportAsync(CsvImportRequest csvImportRequest)
        {
            var response = await _httpClient.PostAsJsonAsync(ImportEndpoints.CsvImport, csvImportRequest);
            return await response.ToBankRespnseAsync<bool>();
        }
    }
}
