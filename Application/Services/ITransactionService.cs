using Common.Responses.Wrappers;
using Domain;

namespace Application.Services
{
    public interface ITransactionService
    {
        Task<int> CreateTransactionAsync(Transaction transaction);
        Task<List<Transaction>> GetTransactionsByAccountNumberAsync(string accountNumber);
    }
}
