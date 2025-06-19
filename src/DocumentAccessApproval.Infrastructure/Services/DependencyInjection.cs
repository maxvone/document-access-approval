using DocumentAccessApproval.Application.Abstractions;
using DocumentAccessApproval.Infrastructure.Auth;
using DocumentAccessApproval.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DocumentAccessApproval.Infrastructure.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("InMem"));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddTransient<INotificationService, NotificationService>();

            return services;
        }
    }
}
