using System.Net.Http.Json;
using Edu.Code.External.Client.Extensions;
using Edu.Code.External.Client.Requests.Compile;
using Edu.Code.External.Client.Responses.Compile;

namespace Edu.Code.External.Client.Apis;

public class CompilerApi
{
    private readonly HttpClient _client;
    private readonly string _clientId;
    private readonly string _secret;

    public CompilerApi(HttpClient client, string clientId, string secret)
    {
        _client = client;
        _clientId = clientId;
        _secret = secret;
    }
    
    public async Task<CompileResponse?> PostExecuteAsync(CompileRequest request)
    {
        const string url = "v1/execute";
        
        var response = await _client.PostAsJsonAsync(url, BuildRequest(request))
            .ConfigureAwait(false);
        
        var result = await response.Content.ReadAsJsonAsync<CompileResponse>()
            .ConfigureAwait(false);
        
        return result;
    }

    private CompileRequest BuildRequest(CompileRequest request)
    {
        request.ClientSecret = _secret;
        request.ClientId = _clientId;

        return request;
    }
}