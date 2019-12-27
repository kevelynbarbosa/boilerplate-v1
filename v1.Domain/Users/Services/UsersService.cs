using System.Collections.Generic;
using MongoDB.Driver;
using v1.Domain.Users.Entities;
using v1.Domain.Users.Services.Interfaces;

namespace v1.Domain.Users.Services
{
    public class UsersService : IUsersService
    {
        private readonly IMongoCollection<User> _usersRepository;

        public UsersService(IMongoDatabase database)
        {
            _usersRepository = database.GetCollection<User>("Users");
        }

        public IEnumerable<User> Get()
        {
            var userList = _usersRepository.Find(x => true).ToEnumerable();

            return userList;
        }

        public User Get(string id)
        {
            var user = _usersRepository.Find(x => x.Id == id).FirstOrDefault();

            return user;
        }

        public User Create(User user)
        {
            _usersRepository.InsertOne(user);

            return user;
        }

        public ReplaceOneResult Update(string id, User user)
        {
            var result = _usersRepository.ReplaceOne(x => x.Id == id, user);

            return result;
        }


        public DeleteResult Delete(User user)
        {
            var result = _usersRepository.DeleteOne(x => x.Id == user.Id);

            return result;
        }
    }
}
