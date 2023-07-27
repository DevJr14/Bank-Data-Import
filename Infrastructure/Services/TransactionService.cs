using Application.Services;
using Domain;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ApplicationDbContext _context;

        public TransactionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateTransactionAsync(Transaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();

            return transaction.TransactionId;
        }

        public async Task<List<Transaction>> GetTransactionsByAccountNumberAsync(string accountNumber)
        {
            return await _context.Transactions
                .Include(trans => trans.Account)
                .Where(trans => trans.Account.AccountNumber == accountNumber)
                .ToListAsync();
        }
    }
}
