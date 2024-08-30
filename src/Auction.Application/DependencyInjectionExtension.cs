using Microsoft.Extensions.DependencyInjection;
using RocketAuction.Application.UseCases.Auctions.GetCurrent;
using RocketAuction.Application.UseCases.Offers.CreateOffer;

namespace RocketAuction.Application;
public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IGetCurrentAuctionUseCase, GetCurrentAuctionUseCase>();
        services.AddScoped<ICreateOfferUseCase, CreateOfferUseCase>();
    }
}
