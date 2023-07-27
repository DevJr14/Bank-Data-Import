using Common;

namespace Domain
{
    public class Account
    {
        public int AccountId { get; set; }
        public string AccountHolder { get; set; }
        public string AccountNumber { get; set; }
        public string BranchCode { get; set; }
        public AccountType AccountType { get; set; }
        public List<Transaction> Transactions { get; set; }

        public Account(string accountHolder, string accountNumber, string branchCode, AccountType accountType)
        {
            AccountHolder = accountHolder;
            AccountNumber = accountNumber;
            BranchCode = branchCode;
            AccountType = accountType;
        }
    }
}