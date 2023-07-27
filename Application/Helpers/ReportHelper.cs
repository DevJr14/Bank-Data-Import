namespace Application.Helpers
{
    public static class ReportHelper
    {
        public static string SetStatus(string statusCode)
        {
            return statusCode switch
            {
                "00" => "Successful",
                "30" => "Disputed",
                _ => "Failed",
            };
        }

        //public static string SetAccountType
    }
}
