namespace Edu.Code.External.Client.Requests.Compile;

public class CompileRequest
{
    public string? ClientId { get; set; }
    
    public string? ClientSecret { get; set; }
    
    public string? Script { get; set; }
    
    public string? Stdin { get; set; }
    
    public string? Language { get; set; }

    public string VersionIndex { get; set; } = "4";
}