namespace Edu.Code.External.Client.Responses.OpenAI.Common;

public sealed class ChoiceResponse
{
    public int Index { get; set; }
    
    public MessageResponse Message { get; set; } = null!;
    
    public string FinishReason { get; set; } = null!;
}