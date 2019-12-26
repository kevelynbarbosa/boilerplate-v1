using MongoDB.Driver;
using System.Collections.Generic;
using v1.Domain.Drivers.Entities;
using v1.Domain.Drivers.Services.Interfaces;

namespace v1.Domain.Drivers.Services
{
    public class DriversService : IDriversService
    {
        private readonly IMongoCollection<Driver> _driversRepository;

        public DriversService(IMongoDatabase database)
        {
            _driversRepository = database.GetCollection<Driver>("Drivers");
        }

        public IEnumerable<Driver> Get()
        {
            var driversList = _driversRepository.Find(x => true).ToEnumerable();

            return driversList;
        }

        public Driver Get(string id)
        {
            var driver = _driversRepository.Find(x => x.Id == id).FirstOrDefault();

            return driver;
        }

        public Driver Create(Driver driver)
        {
            _driversRepository.InsertOne(driver);

            return driver;
        }

        public ReplaceOneResult Update(string id, Driver driver)
        {
            var result = _driversRepository.ReplaceOne(x => x.Id == id, driver);

            return result;
        }


        public DeleteResult Delete(Driver driver)
        {
            var result = _driversRepository.DeleteOne(x => x.Id == driver.Id);

            return result;
        }

    }
}
