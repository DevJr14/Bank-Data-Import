namespace Common.Responses
{
    public class ReportResponse
    {
        public string BranchCode { get; set; }
        public AccountType AccountType { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }
        public int TransactionsCount { get; set; }

        public void SetStatus(string statusCode)
        {
            Status = statusCode switch
            {
                "00" => "Successful",
                "30" => "Disputed",
                _ => "Failed",
            };
        }
    }
}
