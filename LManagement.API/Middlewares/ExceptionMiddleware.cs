using LManagement.API.Models.Responses;
using Microsoft.AspNetCore.Diagnostics;

namespace LManagement.API.Middlewares
{
    public static class ExceptionMiddleware
    {
        public static void ConfigureExceptionHandler(this WebApplication app)
        {
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
                        logger.LogError(contextFeature.Error, "Unhandled exception occurred.");

                        var errorResponse = new ApiResponse<object>
                        {
                            Success = false,
                            Message = "An unexpected error occurred. Please try again later.",
                            Data = null
                        };

                        await context.Response.WriteAsJsonAsync(errorResponse);
                    }
                });
            });
        }
    }
}
