using Common;
using Common.Responses;
using Common.Responses.Wrappers;

namespace Client.Infrastructure.Services
{
    public interface IAccountManager : IManager
    {
        Task<IBankResponse<List<AccountResponse>>> GetAllAsync();
        Task<IBankResponse<AccountResponse>> GetByIdAsync(int accountId);
        Task<IBankResponse<bool>> UpdateAccountAsync(AccountType accountType, int accountId);
    }
}
