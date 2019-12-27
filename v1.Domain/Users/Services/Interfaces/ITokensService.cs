using v1.Domain.Users.Entities;

namespace v1.Domain.Users.Services.Interfaces
{
    public interface ITokensService
    {
        string GenerateToken();
    }
}
