using System.Text.Json;
using Edu.Code.External.Client.Settings;

namespace Edu.Code.External.Client.Extensions;

public static class HttpClientExtensions
{
    public static async Task<T?> ReadAsJsonAsync<T>(this HttpContent content)
    {
        if (content == null)
        {
            throw new ArgumentNullException(nameof(content));
        }

        var contentResponse = await content.ReadAsStringAsync()
            .ConfigureAwait(false);

        return string.IsNullOrEmpty(contentResponse) ? default : JsonSerializer.Deserialize<T>(contentResponse, JsonSerializerSettings.Config);
    }
}