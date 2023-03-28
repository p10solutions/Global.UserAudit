using Global.UserAudit.Application.Contracts.Notifications;
using Global.UserAudit.Application.Contracts.Repositories;
using Global.UserAudit.Application.Features.Users.Commands.UserChange;
using Global.UserAudit.Application.Features.Users.Queries.GetUser;
using Global.UserAudit.Application.Features.Users.Queries.GetUserById;
using Global.UserAudit.Infra.Data;
using Global.UserAudit.Infra.Validation;
using GlobalUserAudit.Infra.Data.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Global.UserAudit.Infra.IoC
{
    public static class UserAuditProvider
    {
        public static IServiceCollection AddProviders(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetUserByIdHandler).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetUserHandler).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(UserChangeCommand).Assembly));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(FailFastValidator<,>));
            services.AddScoped<INotificationsHandler, NotificationHandler>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.Configure<UserAuditDatabaseSettings>(configuration.GetSection("UserAuditDatabase"));
            services.AddSingleton<UserAuditDatabaseSettings>();

            return services;
        }
    }
}
