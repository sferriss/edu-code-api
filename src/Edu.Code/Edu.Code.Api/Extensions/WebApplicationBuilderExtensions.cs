using Edu.Code.Application.Extensions;

namespace Edu.Code.Api.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddEduCodeApi(builder.Configuration.GetConnectionString("EduCode")!);
    }
}