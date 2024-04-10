using frogpay.bootstrapper.Configurations.Exceptions;
using Microsoft.AspNetCore.Builder;

namespace frogpay.bootstrapper.Configurations.Cors;

public static class ExceptionMiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder) =>
        builder.UseMiddleware<ExceptionMiddleware>();
}