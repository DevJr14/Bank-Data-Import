using Client.Infrastructure.Endpoints;
using Common.Responses;
using Common.Responses.Wrappers;

namespace Client.Infrastructure.Services
{
    public class TransactionManager : ITransactionManager
    {
        private readonly HttpClient _httpClient;

        public TransactionManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IBankResponse<List<TransactionResponse>>> GetAccountTransactionsAsync(string accountNumber)
        {
            var response = await _httpClient.GetAsync(TransactionEndpoints.GetAccountTransactions(accountNumber));
            return await response.ToBankRespnseAsync<List<TransactionResponse>>();
        }
    }
}
