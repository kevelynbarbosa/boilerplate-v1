using MongoDB.Driver;
using System.Collections.Generic;
using v1.DTO.Users.Requests;
using v1.DTO.Users.Responses;

namespace v1.Application.Users.AppServices.Interfaces
{
    public interface IUsersAppService
    {
        UserResponse Get(string email);
        UserResponse Create(UserRequest user);
    }
}
