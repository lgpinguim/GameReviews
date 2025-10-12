using GameReviews.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GameReviewsAPI.Configurations;

public static class DatabaseConfiguration
{
    public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        if (services is null) throw new ArgumentNullException(nameof(services));

        services.AddDbContext<GameReviewsContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    }
}