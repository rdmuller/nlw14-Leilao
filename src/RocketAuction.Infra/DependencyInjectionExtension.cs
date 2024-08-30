using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RocketAuction.Domain.Repositories;
using RocketAuction.Domain.Repositories.Auctions;
using RocketAuction.Domain.Repositories.Offers;
using RocketAuction.Domain.Repositories.Users;
using RocketAuction.Domain.Security;
using RocketAuction.Infra.DataAccess;
using RocketAuction.Infra.DataAccess.Repositories;
using RocketAuction.Infra.Services.LoggedUser;

namespace RocketAuction.Infra;
public static class DependencyInjectionExtension
{
    public static void AddInfra(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services);
        AddSecurity(services);
        AddRepositories(services);
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IAuctionReadOnlyRepository, AuctionRepository>();
        services.AddScoped<IUserReadOnlyRepository, UserRepository>();
        services.AddScoped<IOfferWriteOnlyRepository, OfferRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    private static void AddSecurity(IServiceCollection services)
    {
        services.AddScoped<ILoggedUser, LoggedUser>();
    }

    private static void AddDbContext(IServiceCollection services)
    {
        services.AddDbContext<RocketAuctionDbContext>(options =>
        {
            options.UseSqlite(@"Data Source=C:\Users\mulle\Documents\Estudos\csharp\Leilao\leilaoDbNLW.db");
        });
    }
}
