using RocketAuction.Communication.Requests;

namespace RocketAuction.Application.UseCases.Offers.CreateOffer;
public interface ICreateOfferUseCase
{
    Task<int> Execute(int itemId, RequestCreateOfferJson request);
}
