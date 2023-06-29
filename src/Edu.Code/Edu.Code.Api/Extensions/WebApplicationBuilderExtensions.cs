using Edu.Code.Application.Extensions;

namespace Edu.Code.Api.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        var aa = builder.Configuration.GetConnectionString("EduCode");
        builder.Services.AddEduCodeApi(builder.Configuration.GetConnectionString("EduCode")!);
    }
}