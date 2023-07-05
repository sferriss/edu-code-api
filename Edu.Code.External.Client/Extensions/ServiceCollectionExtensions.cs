using Edu.Code.External.Client.HttpHandlers;
using Microsoft.Extensions.DependencyInjection;

namespace Edu.Code.External.Client.Extensions;

public static class ServiceCollectionExtensions
{
    public static IHttpClientBuilder AddCompilerApi(this IServiceCollection services)
    {
        services.AddTransient<EnsureSuccessCodeHandler>();

        return services.AddHttpClient<CompilerApiClient>()
            .AddHttpMessageHandler<EnsureSuccessCodeHandler>();
    }
}