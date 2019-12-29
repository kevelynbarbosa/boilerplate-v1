using v1.DTO.Users.Requests;
using v1.DTO.Users.Responses;

namespace v1.Application.Users.AppServices.Interfaces
{
    public interface IUsersAppService
    {
        TokenResponse Login(UserRequest request);
        UserResponse Create(UserRequest user);
    }
}
