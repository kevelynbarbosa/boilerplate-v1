using AutoMapper;
using System;
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
        private readonly ITokensService _tokensService;

        public UsersAppService(IMapper mapper, IUsersService _usersService, ITokensService tokensService)
        {
            this._usersService = _usersService;
            this._mapper = mapper;
            this._tokensService = tokensService;
        }

        public UserResponse Create(UserRequest request)
        {
            var user = new User(request.Email, request.Password);

            var userCreated = _usersService.Create(user);

            return _mapper.Map<UserResponse>(userCreated);
        }

        public TokenResponse Login(UserRequest request)
        {
            var user = this._usersService.Get(request.Email);

            if (user.Password != request.Password)
                throw new Exception("Not Authorized");

            return new TokenResponse
            {
                Token= (_tokensService.GenerateToken())
            };           
        }

    }
}
