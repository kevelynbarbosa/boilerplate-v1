using MongoDB.Driver;
using System.Collections.Generic;
using v1.Domain.Drivers.Entities;

namespace v1.Domain.Drivers.Services.Interfaces
{
    public interface IDriversService
    {
        IEnumerable<Driver> Get();
        Driver Get(string id);
        Driver Create(Driver driver);
        ReplaceOneResult Update(string id, Driver driver);
        DeleteResult Delete(Driver driver);
    }
}
