namespace Common.Responses.Wrappers
{
    /// <summary>
    /// Generic response wrapper interface for all outgoing response
    /// </summary>s
    /// <typeparam name="T"></typeparam>
    public interface IBankResponse<out T>
    {
        List<string> Messages { get; set; }
        bool IsSuccessful { get; set; }
        T Data { get; }
    }
}
