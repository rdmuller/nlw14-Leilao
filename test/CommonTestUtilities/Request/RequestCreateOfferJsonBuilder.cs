using Bogus;
using RocketAuction.Communication.Requests;

namespace CommonTestUtilities.Request;
public class RequestCreateOfferJsonBuilder
{
    public static RequestCreateOfferJson Build()
    {
        return new Faker<RequestCreateOfferJson>()
            .RuleFor(r => r.Price, faker => faker.Random.Decimal());
    }
}
