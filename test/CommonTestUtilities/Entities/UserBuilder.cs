using Bogus;
using RocketAuction.Domain.Entities;

namespace CommonTestUtilities.Entities;
public class UserBuilder
{
    public static User Build()
    {
        return new Faker<User>()
            .RuleFor(u => u.Id, faker => faker.Random.Int(min: 1))
            .RuleFor(u => u.Name, faker => faker.Person.FirstName)
            .RuleFor(u => u.Email, (faker, u) => faker.Internet.Email(firstName: u.Name));
    }
}
