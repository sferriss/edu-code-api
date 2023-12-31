﻿using System.Text.Json.Serialization;

namespace Edu.Code.External.Client.Responses.OpenAI.Common;

public sealed class UsageResponse
{
    [JsonPropertyName("prompt_tokens")]
    public int PromptTokens { get; set; }
    
    [JsonPropertyName("completion_tokens")]
    public int CompletionTokens { get; set; }
    
    [JsonPropertyName("total_tokens")]
    public int TotalTokens { get; set; }
}