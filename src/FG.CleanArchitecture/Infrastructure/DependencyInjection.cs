using Autofac;
using Domain.Entities.Identity;
using Infrastructure.Options;
using Infrastructure.Persistence.DbContext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.ConstrainedExecution;

namespace Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, Action<ContainerBuilder> containerBuilder = null)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("SqlCon"));
        });

        services.AddIdentity<AppUser, IdentityRole<Guid>>(config =>
        {
            config.Password.RequiredLength = 5;
            config.Password.RequireDigit = false;
            config.Password.RequireLowercase = false;
            config.Password.RequireNonAlphanumeric = false;
            config.Password.RequireUppercase = false;
            config.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            config.Lockout.MaxFailedAccessAttempts = 3;
            config.Lockout.AllowedForNewUsers = true;
        })
        .AddEntityFrameworkStores<AppDbContext>()
        .AddDefaultTokenProviders();
        services.Configure<JwtOptions>(configuration.GetSection("JwtOptions"));
        services.ConfigureOptions<JwtTokenOptionsSetup>();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer();


        var builder = new ContainerBuilder();
        builder.RegisterModule<InfrastructureModule>();
        containerBuilder?.Invoke(builder);

        return services;
    }

    //Add UnitOfWork



}
