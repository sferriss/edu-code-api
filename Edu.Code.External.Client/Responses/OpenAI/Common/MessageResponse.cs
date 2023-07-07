namespace Edu.Code.External.Client.Responses.OpenAI.Common;

public sealed class MessageResponse
{
    public string Role { get; set; } = null!;
    
    public string Content { get; set; } = null!;
}