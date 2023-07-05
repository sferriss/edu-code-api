namespace Edu.Code.External.Client.Responses.Compile;

public class CompileResponse
{
    public string? Output { get; set; }
    
    public int StatusCode { get; set; }
    
    public string? Memory { get; set; }
    
    public string? CpuTime { get; set; }
}