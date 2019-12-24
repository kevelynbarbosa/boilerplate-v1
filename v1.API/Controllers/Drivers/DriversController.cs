using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using v1.Domain.Drivers.Entities;
using v1.Domain.Drivers.Services;

namespace v1.API.Controllers.Drivers
{
    [ApiController]
    [Route("[controller]")]
    public class DriversController : ControllerBase
    {
        private readonly DriversService _driversService;
        private readonly ILogger<WeatherForecastController> _logger;

        public DriversController(ILogger<WeatherForecastController> logger, DriversService driversService)
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
        public Driver Create()
        {
            var driver = new Driver("Kevelyn Barbosa", "21");
            
            return _driversService.Create(driver);
        }
    }
}
