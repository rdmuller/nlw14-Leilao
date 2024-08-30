using RocketAuction.Communication.Requests;
using RocketAuction.Domain.Entities;
using RocketAuction.Domain.Repositories;
using RocketAuction.Domain.Repositories.Offers;
using RocketAuction.Domain.Security;

namespace RocketAuction.Application.UseCases.Offers.CreateOffer;
public class CreateOfferUseCase : ICreateOfferUseCase
{
    private readonly ILoggedUser _loggedUser;
    private readonly IOfferWriteOnlyRepository _offerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateOfferUseCase(
        ILoggedUser loggedUser,
        IOfferWriteOnlyRepository offerRepository,
        IUnitOfWork unitOfWork)
    {
        _loggedUser = loggedUser;
        _offerRepository = offerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Execute(int itemId, RequestCreateOfferJson request)
    {
        var user = await _loggedUser.User();

        var offer = new Offer
        {
            CreatedOn = DateTime.Now,
            ItemId = itemId,
            Price = request.Price,
            UserId = user.Id,
        };

        await _offerRepository.Add(offer);
        await _unitOfWork.Commit();

        return offer.Id;
    }
}
