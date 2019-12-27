using MongoDB.Driver;
using System.Collections.Generic;
using v1.Domain.Users.Entities;

namespace v1.Domain.Users.Services.Interfaces
{
    public interface IUsersService
    {
        IEnumerable<User> Get();
        User Get(string id);
        User Create(User driver);
        ReplaceOneResult Update(string id, User driver);
        DeleteResult Delete(User driver);
    }
}
