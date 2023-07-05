using System.Net.Http.Headers;
using System.Net.Mime;
using Edu.Code.External.Client.Apis;

namespace Edu.Code.External.Client;

public class CompilerApiClient
{
    public CompilerApiClient(HttpClient client)
    {
        ArgumentNullException.ThrowIfNull(client, nameof(client));
        
        var baseUrl = new Uri(Environment.GetEnvironmentVariable("COMPILER__URL")!);
        var clientId = Environment.GetEnvironmentVariable("COMPILER__CLIENTID")!;
        var secret = Environment.GetEnvironmentVariable("COMPILER__SECRET")!;
        
        client.BaseAddress = baseUrl;
        client.DefaultRequestHeaders.Accept
            .Add(new MediaTypeWithQualityHeaderValue(MediaTypeNames.Application.Json));

        CompilerApi = new CompilerApi(client, clientId, secret);
    }

    public CompilerApi CompilerApi { get; }
}