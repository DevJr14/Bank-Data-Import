using Domain;

namespace Application.Services
{
    public interface IBankAccountService
    {
        Task<Account> GetBankAccountByIdAsync(int accountId);
        Task<List<Account>> GetAllAccountsAsync();
        Task<Account> UpdateAccountAsync(Account account);
    }
}
