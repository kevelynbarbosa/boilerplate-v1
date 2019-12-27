using AutoMapper;
using v1.Application.Users.AppServices.Interfaces;
using v1.Domain.Users.Entities;
using v1.Domain.Users.Services.Interfaces;
using v1.DTO.Users.Requests;
using v1.DTO.Users.Responses;

namespace v1.Application.Users.AppServices
{
    public class UsersAppService : IUsersAppService
    {
        private readonly IMapper _mapper;
        private readonly IUsersService _usersService;

        public UsersAppService(IMapper mapper, IUsersService _usersService)
        {
            this._usersService = _usersService;
            this._mapper = mapper;
        }

        public UserResponse Create(UserRequest request)
        {
            var user = new User(request.Email, request.Password);

            var userCreated = _usersService.Create(user);

            return _mapper.Map<UserResponse>(userCreated);
        }

        public UserResponse Get(string email)
        {
            var user = this._usersService.Get(email);

            return _mapper.Map<UserResponse>(user);
        }

    }
}
