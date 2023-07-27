namespace Client.Infrastructure.Endpoints
{
    public static class TransactionEndpoints
    {
        public static string GetAccountTransactions(string accountNumber)
            => $"api/transactions/{accountNumber}";
    }
}
