using Edu.Code.External.Client.Responses.OpenAI.Common;

namespace Edu.Code.External.Client.Responses.OpenAI;

public sealed class GptConversationResponse
{
    public string Id { get; set; } = null!;
    
    public string Object { get; set; } = null!;
    
    public long Created { get; set; }
    
    public List<ChoiceResponse> Choices { get; set; } = null!;
    
    public UsageResponse Usage { get; set; } = null!;
}