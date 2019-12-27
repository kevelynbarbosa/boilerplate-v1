using AutoMapper;
using v1.Domain.Users.Entities;
using v1.DTO.Users.Responses;

namespace v1.Application.Users.Profiles
{
    public class UsersAppProfile : Profile
    {
        public UsersAppProfile()
        {
            CreateMap<User, UserResponse>();
        }
    }
}
