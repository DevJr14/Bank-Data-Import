using Client.Infrastructure.Endpoints;
using Common;
using Common.Responses;
using Common.Responses.Wrappers;
using System.Net.Http.Json;

namespace Client.Infrastructure.Services
{
    public class AccountManager : IAccountManager
    {
        private readonly HttpClient _httpClient;

        public AccountManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IBankResponse<List<AccountResponse>>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync(AccountEndpoints.GetAllAccounts);
            return await response.ToBankRespnseAsync<List<AccountResponse>>();
        }

        public async Task<IBankResponse<AccountResponse>> GetByIdAsync(int accountId)
        {
            var response = await _httpClient.GetAsync(AccountEndpoints.GetById(accountId));
            return await response.ToBankRespnseAsync<AccountResponse>();
        }

        public async Task<IBankResponse<bool>> UpdateAccountAsync(AccountType accountType, int accountId)
        {
            var response = await _httpClient.PutAsJsonAsync(AccountEndpoints.UpdateAccount(accountId), accountType);
            return await response.ToBankRespnseAsync<bool>();
        }
    }
}
