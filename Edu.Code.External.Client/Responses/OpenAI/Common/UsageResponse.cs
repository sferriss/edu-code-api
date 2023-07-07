namespace Edu.Code.External.Client.Responses.OpenAI.Common;

public sealed class UsageResponse
{
    public int PromptTokens { get; set; }
    
    public int CompletionTokens { get; set; }
    
    public int TotalTokens { get; set; }
}