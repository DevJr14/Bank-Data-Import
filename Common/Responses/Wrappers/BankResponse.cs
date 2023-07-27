namespace Common.Responses.Wrappers
{
    public class BankResponse<T> : IBankResponse<T>
    {
        public BankResponse()
        {

        }

        public List<string> Messages { get; set; } = new List<string>();

        public bool IsSuccessful { get; set; }

        public T Data { get; set; }

        #region Synchronous

        public static BankResponse<T> Fail(string message)
        {
            return new BankResponse<T> { IsSuccessful = false, Messages = new List<string>() { message } };
        }

        public static BankResponse<T> Success(string message)
        {
            return new BankResponse<T> { IsSuccessful = true, Messages = new List<string>() { message } };
        }
        public static BankResponse<T> Success(T data)
        {
            return new BankResponse<T> { IsSuccessful = true, Data = data };
        }
        #endregion

        #region Asynchronous

        public static Task<BankResponse<T>> FailAsync(string message)
        {
            return Task.FromResult(Fail(message));
        }

        public static Task<BankResponse<T>> SuccessAsync(string message)
        {
            return Task.FromResult(Success(message));
        }

        public static Task<BankResponse<T>> SuccessAsync(T data)
        {
            return Task.FromResult(Success(data));
        } 
        #endregion
    }
}
