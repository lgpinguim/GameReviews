using GameReviews.Domain.Interfaces;
using GameReviews.Infra.Data.Context;
using GameReviews.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GameReviews.Infra.CrossCutting.IoC;

public class NativeInjectionBootstrapper
{
    public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
    {
        // Unit of Work
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Repositories 
        services.AddScoped<IAchievementRepository, AchievementRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IDeveloperRepository, DeveloperRepository>();
        services.AddScoped<IGameRepository, GameRepository>();
        services.AddScoped<ILanguageSupportRepository, LanguageSupportRepository>();
        services.AddScoped<IPlatformRepository, PlatformRepository>();
        services.AddScoped<IPublisherRepository, PublisherRepository>();
        services.AddScoped<IReviewRepository, ReviewRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        // Application Services 
        // 
    }
}