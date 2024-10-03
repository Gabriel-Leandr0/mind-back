using Microsoft.OpenApi.Models;

namespace Project.WebApi.Configurations;

public static class SwaggerConfigurations
{
    public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(opt =>
        {
            opt.AddSecurityDefinition("Bearer",
             new OpenApiSecurityScheme
             {
                 Description = "JWT Authorization header using the Bearer scheme.",
                 Type = SecuritySchemeType.Http,
                 Scheme = "bearer"
             });

            opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
            {
               new OpenApiSecurityScheme{
                    Reference = new OpenApiReference{
                        Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                    }
               },new List<string>()
            }
                });
        });


        return services;
    }

    public static WebApplication UseSwaggerConfiguration(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("v1/swagger.json", "Project API"));

        return app;
    }
}
