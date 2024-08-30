using Bogus;
using RocketAuction.Domain.Entities;

namespace CommonTestUtilities.Entities;
public class OfferBuilder
{
    public static Offer Build()
    {
        var offer = new Faker<Offer>()
            .RuleFor(o => o.Id, faker => faker.Random.Int(min: 0))
            .RuleFor(o => o.CreatedOn, faker => faker.Date.Past())
            .RuleFor(o => o.ItemId, faker => faker.Random.Int(min:0))
            .RuleFor(o => o.UserId, faker => faker.Random.Int(min:0))
            .RuleFor(o => o.Price, faker => faker.Random.Decimal());

        return offer;
    }
}
