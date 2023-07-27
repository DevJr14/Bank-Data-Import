namespace Common.Requests
{
    public class CreateAccountRequest
    {
        public string AccountHolder { get; set; }
        public string AccountNumber { get; set; }
        public string BranchCode { get; set; }
        public AccountType AccountType { get; set; }
    }
}
