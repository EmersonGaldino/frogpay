using Microsoft.AspNetCore.Builder;

namespace frogpay.bootstrapper.Configurations.Swagger;

public static class ApplicationBuildExtensionsSwagger
{
    public static void UseSwaggerConfig(this IApplicationBuilder app)
    {
        app.UseSwaggerUI(swagger =>
        {
            swagger.SwaggerEndpoint("/swagger/v1/swagger.json", "Frog-Pay-V1");
            swagger.RoutePrefix = string.Empty;
        });
    }
}