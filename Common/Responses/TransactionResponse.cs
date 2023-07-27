namespace Common.Responses
{
    public class TransactionResponse
    {
        public int TransactionId { get; set; }
        public int AccountId { get; set; }
        public DateTime TransactionDate { get; set; }
        public Decimal Amount { get; set; }
        public string Status { get; set; }
        public DateTime EffectiveStatusDate { get; set; }
        public string TimeBreached { get; set; }

        public AccountResponse Account { get; set; }
    }
}
