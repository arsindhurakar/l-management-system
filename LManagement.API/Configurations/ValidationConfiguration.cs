using LManagement.API.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace LManagement.API.Configuration
{
    public static class ValidationConfiguration
    {
        private const string ValidationLoggerName = "LManagement.API.Validation";

        public static void ConfigureValidationBehavior(this IServiceCollection services)
        {
            services.AddControllers()
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.InvalidModelStateResponseFactory = CreateValidationErrorResponse;
                })
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.DefaultIgnoreCondition =
                        System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
                });
        }

        private static BadRequestObjectResult CreateValidationErrorResponse(ActionContext context)
        {
            var errors = context.ModelState
                .Where(e => e.Value?.Errors.Count > 0)
                .SelectMany(e => e.Value!.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();

            var loggerFactory = context.HttpContext.RequestServices
                .GetRequiredService<ILoggerFactory>();
            var logger = loggerFactory.CreateLogger(ValidationLoggerName);

            var endpoint = context.HttpContext.GetEndpoint()?.DisplayName ?? "Unknown";
            logger.LogWarning("Validation failed for {Endpoint}. Errors: {Errors}",
                endpoint, errors);

            var errorResponse = new ApiErrorResponse<object>
            {
                Success = false,
                Message = "Validation failed.",
                Data = null,
                Errors = errors
            };

            return new BadRequestObjectResult(errorResponse);
        }
    }
}