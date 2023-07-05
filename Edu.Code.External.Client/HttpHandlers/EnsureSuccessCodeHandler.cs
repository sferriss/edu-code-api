using Serilog;
namespace Edu.Code.External.Client.HttpHandlers;

public class EnsureSuccessCodeHandler : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var response = await base.SendAsync(request, cancellationToken);

        ArgumentNullException.ThrowIfNull(response, nameof(response));

        if (response.IsSuccessStatusCode)
        {
            return response;
        }

        var contentResponse = await response.Content.ReadAsStringAsync(cancellationToken);

        Log.Error(
            "Error: Request URL: {url}, Response Status: {status}, Response Content: {content}",
            request.RequestUri,
            response.StatusCode,
            contentResponse);

        throw new InvalidOperationException("Erro ao executar chamada externa");
    }
}