using System.Text.Json.Serialization;

namespace Edu.Code.External.Client.Responses.OpenAI.Common;

public sealed class ChoiceResponse
{
    public int Index { get; set; }
    
    public MessageResponse Message { get; set; } = null!;
    
    [JsonPropertyName("finish_reason")]
    public string FinishReason { get; set; } = null!;
}