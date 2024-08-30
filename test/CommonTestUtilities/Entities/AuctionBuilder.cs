using Bogus;
using RocketAuction.Domain.Entities;
using RocketAuction.Domain.Enums;

namespace CommonTestUtilities.Entities;
internal class AuctionBuilder
{
    public static Auction Build()
    {
        var auction = new Faker<Auction>()
            .RuleFor(a => a.Id, _ => 1)
            .RuleFor(a => a.Name, faker => faker.Lorem.Word())
            .RuleFor(a => a.Starts, faker => faker.Date.Past())
            .RuleFor(a => a.Ends, faker => faker.Date.Future())
            .RuleFor(a => a.Items, (faker, auction) => new List<Item>
            {
                new Item
                {
                    Id = 1,
                    Name = faker.Commerce.ProductName(),
                    Brand = faker.Commerce.Department(),
                    BasePrice = faker.Random.Decimal(),
                    AuctionId = auction.Id,
                    Condition = faker.PickRandom<Condition>()
                }
            });

        return auction;
    }
}
