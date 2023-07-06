using System.Net.Http.Headers;
using System.Net.Mime;
using Edu.Code.External.Client.Apis;

namespace Edu.Code.External.Client.Settings;

public class OpenAiApiClient
{
    public OpenAiApiClient(HttpClient client)
    {
        ArgumentNullException.ThrowIfNull(client, nameof(client));
        
        var baseUrl = new Uri(Environment.GetEnvironmentVariable("OPENAI__URL")!);
        var apiKey = Environment.GetEnvironmentVariable("OPENAI__APIKEY")!;
        var model = Environment.GetEnvironmentVariable("OPENAI__MODEL")!;
        var maxTokenResponse = Environment.GetEnvironmentVariable("OPENAI__MAXTOKENRESPONSE")!;

        client.BaseAddress = baseUrl;
        client.DefaultRequestHeaders.Accept
            .Add(new MediaTypeWithQualityHeaderValue(MediaTypeNames.Application.Json));
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

        OpenAiApi = new OpenAiApi(client, model, Convert.ToInt32(maxTokenResponse));
    }

    public OpenAiApi OpenAiApi { get; }
}