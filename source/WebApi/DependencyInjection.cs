using Project.Application.Common.Interfaces;
using Project.Infrastructure.Data;
using Project.WebApiApi.Services;
using Microsoft.AspNetCore.Mvc;
using Project.WebApi.Configurations;
using System.Globalization;
using Project.Domain.Notifications;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
    {
        var cultureInfo = new CultureInfo("pt-BR");
        cultureInfo.NumberFormat.CurrencySymbol = "R$";

        CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
        CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

        services.AddScoped<IUser, CurrentUser>();

        services.AddNotifications();

        services.AddHttpContextAccessor();

        services.AddControllers();

        services.AddHealthChecks()
            .AddDbContextCheck<ApplicationDbContext>();

        services.AddExceptionHandler<CustomExceptionHandler>();

        // Customise default API behaviour
        services.Configure<ApiBehaviorOptions>(options =>
            options.SuppressModelStateInvalidFilter = true);

        services.AddSwaggerConfiguration();

        services.AddApplications(configuration);

        return services;
    }
    private static IServiceCollection AddNotifications(this IServiceCollection services)
    {
        services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
        services.AddScoped<INotificationHandler<DomainSuccesNotification>, DomainSuccesNotificationHandler>();

        return services;
    }


    private static IServiceCollection AddApplications(this IServiceCollection services, IConfiguration configuration)
    {
        
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(x =>
            {
                var key = Encoding.UTF8.GetBytes(configuration["Jwt:SecurityKey"] ?? string.Empty);

                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });
            
        return services;
    }
}
