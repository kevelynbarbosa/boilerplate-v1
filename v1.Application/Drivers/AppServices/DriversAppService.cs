using AutoMapper;
using MongoDB.Driver;
using System.Collections.Generic;
using v1.Application.Drivers.AppServices.Interfaces;
using v1.Domain.Drivers.Entities;
using v1.Domain.Drivers.Services.Interfaces;
using v1.DTO.Drivers.Requests;
using v1.DTO.Drivers.Responses;

namespace v1.Application.Drivers.AppServices
{
    public class DriversAppService : IDriversAppService
    {
        private readonly IMapper _mapper;
        private readonly IDriversService _driversService;

        public DriversAppService(IMapper mapper, IDriversService driversService)
        {
            this._driversService = driversService;
            this._mapper = mapper;
        }

        public DriverResponse Create(DriverRequest request)
        {
            var driver = new Driver(request.Name, request.BirthDate, request.CPF, request.City, request.CnhNumber, request.CnhCategory, request.CnhValidate);

            var driverCreated = _driversService.Create(driver);

            return _mapper.Map<DriverResponse>(driverCreated);
        }

        public IEnumerable<DriverResponse> Get()
        {
            var drivers = _driversService.Get();

            return _mapper.Map<IEnumerable<DriverResponse>>(drivers);
        }

        public DriverResponse Get(string id)
        {
            var driver = _driversService.Get(id);

            return _mapper.Map<DriverResponse>(driver);
        }


        public DeleteResult Delete(string id)
        {
            var driver = _driversService.Get(id);

            return _driversService.Delete(driver);
        }

        public ReplaceOneResult Update(string id, DriverRequest request)
        {
            var driver = _driversService.Get(id);

            driver.Name = request.Name;
            driver.BirthDate = request.BirthDate;
            driver.CPF = request.CPF;
            driver.City = request.City;
            driver.CnhNumber = request.CnhNumber;
            driver.CnhCategory = request.CnhCategory;
            driver.CnhValidate = request.CnhValidate;

            return _driversService.Update(id, driver);
        }

    }
}
