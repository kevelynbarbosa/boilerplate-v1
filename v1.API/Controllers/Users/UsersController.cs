﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using v1.Application.Users.AppServices.Interfaces;
using v1.DTO.Users.Requests;

namespace v1.API.Controllers.Users
{
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersAppService _usersAppService;
        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger, IUsersAppService usersAppService)
        {
            _logger = logger;
            _usersAppService = usersAppService;
        }


        [HttpPost]
        [Route("{id}")]
        public IActionResult Login([FromRoute] string id)
            => Ok(_usersAppService.Get(id));

        [HttpPost]
        [Route("")]
        public IActionResult Register([FromBody] UserRequest request)
            => Ok(_usersAppService.Create(request));
    }
}
