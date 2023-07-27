using Common;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context
{
    internal class AccountEntityConfig : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder
                .ToTable("Accounts", "Banking");

            builder
                .Property(acc => acc.AccountType)
                .HasConversion(
                    enumValue => enumValue.ToString(),
                    dbValue => Enum.Parse<AccountType>(dbValue));

            builder
                .HasIndex(acc => acc.AccountNumber)
                .HasDatabaseName("IX_Accounts_AccountNumber");

            builder
                .HasIndex(acc => acc.BranchCode)
                .HasDatabaseName("IX_Accounts_BranchCode");
        }
    }

    internal class TransactionEntityConfig : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder
                .ToTable("Transactions", "Banking");

            builder
                .HasIndex(trans => trans.TransactionDate)
                .HasDatabaseName("IX_Transactions_TransactionDate");
            builder
                .HasIndex(trans => trans.EffectiveStatusDate)
                .HasDatabaseName("IX_Transactions_EffectiveStatusDate");
            builder
                .HasIndex(trans => trans.Status)
                .HasDatabaseName("IX_Transactions_Status");
        }
    }
}
