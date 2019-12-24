using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using v1.Domain.Drivers.Entities;
using v1.Domain.Drivers.Services.Interfaces;
using v1.DTO.Drivers.Requests;

namespace v1.API.Controllers.Drivers
{
    [ApiController]
    [Route("[controller]")]
    public class DriversController : ControllerBase
    {
        private readonly IDriversService _driversService;
        private readonly ILogger<DriversController> _logger;

        public DriversController(ILogger<DriversController> logger, IDriversService driversService)
        {
            _logger = logger;
            _driversService = driversService;
        }

        [HttpGet]
        public IEnumerable<Driver> Get()
        {
            return _driversService.Get();
        }

        [HttpPost]
        public Driver Create([FromBody] DriverRequest request)
        {
            var driver = new Driver(request.Name, request.Age);
            
            return _driversService.Create(driver);
        }
    }
}
