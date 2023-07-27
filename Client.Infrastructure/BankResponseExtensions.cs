using Common.Responses.Wrappers;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Client.Infrastructure
{
    internal static class BankResponseExtensions
    {
        internal static async Task<IBankResponse<T>> ToBankRespnseAsync<T>(this HttpResponseMessage response)
        {
            var responseAsString = await response.Content.ReadAsStringAsync();
            var responseObject = JsonSerializer.Deserialize<BankResponse<T>>(responseAsString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                ReferenceHandler = ReferenceHandler.Preserve
            });
            return responseObject;
        }
    }
}