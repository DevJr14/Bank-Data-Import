namespace Common.Requests
{
    public class CsvImportData
    {
        public int Id { get; set; }
        public string AccountHolder { get; set; }
        public string BranchCode { get; set; }
        public string AccountNumber { get; set; }
        public AccountType AccountType { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public DateTime EffectiveStatusDate { get; set; }
    }
}
