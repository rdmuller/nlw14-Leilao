using RocketAuction.Domain.Repositories.Users;

namespace RocketAuction.Application.UseCases.Users;
public class GetUser
{
    private readonly IUserReadOnlyRepository _repository;

    public GetUser(IUserReadOnlyRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> EmailExists(string email)
    {
        return await _repository.ExistUserWithEmail(email);
    }
}
