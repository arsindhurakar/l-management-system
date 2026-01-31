namespace LManagement.API.Configuration
{
    public static class SwaggerConfiguration
    {
        private const string ApiVersion = "v1";
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(ApiVersion, new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "L Management System API",
                    Version = ApiVersion,
                    Description = "Initial release."
                });

                // Add more Swagger configurations here if needed
            });
        }

        public static void UseSwaggerConfiguration(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint($"/swagger/{ApiVersion}/swagger.json", $"Lead Management API {ApiVersion}");
                });
            }
        }
    }
}