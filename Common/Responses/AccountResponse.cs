namespace Common.Responses
{
    public class AccountResponse
    {
        public int AccountId { get; set; }
        public string AccountHolder { get; set; }
        public string AccountNumber { get; set; }
        public string BranchCode { get; set; }
        public AccountType AccountType { get; set; }

        public List<TransactionResponse> Transactions { get; set; }
    }
}
