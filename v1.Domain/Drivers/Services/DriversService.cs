using MongoDB.Driver;
using System.Collections.Generic;
using v1.Domain.Drivers.Entities;

namespace v1.Domain.Drivers.Services
{
    public class DriversService
    {
        private readonly IMongoCollection<Driver> drivers;

        public DriversService(IMongoDatabase database)
        {
            drivers = database.GetCollection<Driver>("Drivers");
        }

        public List<Driver> Get()
        {
            return drivers.Find(driver => true).ToList();
        }

        public Driver Get(string id)
        {
            return drivers.Find(driver => driver.Id == id).FirstOrDefault();
        }

        public Driver Create(Driver driver)
        {
            drivers.InsertOne(driver);

            return driver;
        }

        public void Update(string id, Driver driver)
        {
            drivers.ReplaceOne(car => car.Id == id, driver);
        }

        public void Remove(Driver driver)
        {
            drivers.DeleteOne(car => car.Id == driver.Id);
        }

        public void Remove(string id)
        {
            drivers.DeleteOne(car => car.Id == id);
        }
    }
}
