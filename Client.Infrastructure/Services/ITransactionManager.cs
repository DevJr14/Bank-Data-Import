using Common.Responses;
using Common.Responses.Wrappers;

namespace Client.Infrastructure.Services
{
    public interface ITransactionManager : IManager
    {
        Task<IBankResponse<List<TransactionResponse>>> GetAccountTransactionsAsync(string accountNumber);
    }
}
