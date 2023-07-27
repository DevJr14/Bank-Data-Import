namespace Domain
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int AccountId { get; set; }
        public DateTime TransactionDate { get; set; }
        public Decimal Amount { get; set; }
        public string Status { get; set; }
        public DateTime EffectiveStatusDate { get; set; }
        public string TimeBreached { get; set; }

        public Account Account { get; set; }

        public Transaction(int accountId, DateTime transactionDate, decimal amount, string status, DateTime effectiveStatusDate)
        {
            AccountId = accountId;
            TransactionDate = transactionDate;
            Amount = amount;
            Status = status;
            EffectiveStatusDate = effectiveStatusDate;
            TimeBreached = CalculateTimeBreached();
        }

        /// <summary>
        /// Function to calculate the "Time Breached" column value based on the <see cref="EffectiveStatusDate"/> and <see cref="TransactionDate"/>
        /// </summary>
        /// <returns>'Yes' when the difference in days is greater than 7, otherwise 'No' </returns>
        private string CalculateTimeBreached()
        {
            TimeSpan difference = EffectiveStatusDate - TransactionDate;
            int daysDifference = (int)difference.TotalDays;

            return daysDifference > 7 ? "Yes" : "No";
        }
    }
}
