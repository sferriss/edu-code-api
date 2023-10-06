using System.Net.Http.Json;
using Edu.Code.External.Client.Extensions;
using Edu.Code.External.Client.Requests.OpenAI;
using Edu.Code.External.Client.Responses.OpenAI;

namespace Edu.Code.External.Client.Apis;

public class OpenAiApi
{
    private readonly HttpClient _client;
    private readonly string _model;
    private readonly int _maxtoken;

    public OpenAiApi(HttpClient client, string model, int maxtoken)
    {
        _client = client;
        _model = model;
        _maxtoken = maxtoken;
    }
    
    public async Task<GptConversationResponse?> PostGptConversationAsync(GptConversationRequest conversationRequest)
    {
        const string url = "v1/chat/completions";

        conversationRequest.Model = _model;
        conversationRequest.Temperature = 0.4;
        conversationRequest.MaxToken = _maxtoken;
        

        var response = await _client.PostAsJsonAsync(url, conversationRequest)
            .ConfigureAwait(false);
        
        var result = await response.Content.ReadAsJsonAsync<GptConversationResponse>()
            .ConfigureAwait(false);
        
        return result;
    }
}