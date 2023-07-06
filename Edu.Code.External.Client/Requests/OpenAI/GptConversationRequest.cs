using System.Text.Json.Serialization;

namespace Edu.Code.External.Client.Requests.OpenAI;

public class GptConversationRequest
{
    public RoleContent[] Messages { get; set; } = null!;
    
    public string Model { get; set; } = null!;
    
    public double Temperature { get; set; }
    
    [JsonPropertyName("max_tokens")]
    public int MaxToken { get; set; }
}

public class RoleContent
{
    public string Role { get; set; } = null!;
    
    public string Content { get; set; } = null!;
}