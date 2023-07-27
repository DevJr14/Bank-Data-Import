namespace Client.Infrastructure.Endpoints
{
    public static class AccountEndpoints
    {
        public const string GetAllAccounts = "api/accounts/all";
        public static string GetById(int accountId)
            => $"api/accounts/{accountId}";
        public static string UpdateAccount(int accountId)
            => $"api/accounts/{accountId}";
    }
}
