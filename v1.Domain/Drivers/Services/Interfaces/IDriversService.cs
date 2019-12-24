using System.Collections.Generic;
using v1.Domain.Drivers.Entities;

namespace v1.Domain.Drivers.Services.Interfaces
{
    public interface IDriversService
    {
        List<Driver> Get();

        Driver Get(string id);

        Driver Create(Driver driver);

        void Update(string id, Driver driver);

        void Remove(Driver driver);

        void Remove(string id);
    }
}
