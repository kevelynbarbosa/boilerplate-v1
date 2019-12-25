using MongoDB.Driver;
using System.Collections.Generic;
using v1.DTO.Drivers.Requests;
using v1.DTO.Drivers.Responses;

namespace v1.Application.Drivers.AppServices.Interfaces
{
    public interface IDriversAppService
    {
        IEnumerable<DriverResponse> Get();
        DriverResponse Get(string id);
        DriverResponse Create(DriverRequest driver);
        ReplaceOneResult Update(string id, DriverRequest driver);
        DeleteResult Delete(string id);
    }
}
