using Microsoft.Extensions.Options;
using Models.API.UserAPI;
using MongoDB.Driver;
using UserAPI.DBConnections;

namespace UserAPI.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly IMongoCollection<User> _playlistCollection;


        public UserRepo(IOptions<DBSettings> mongoDBSettings)
        {

            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _playlistCollection = database.GetCollection<User>(mongoDBSettings.Value.CollectionName);
        }

        public Task<bool> deleteUser(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> getAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<User> getSingleUser(string id)
        {
            throw new NotImplementedException();
        }

        public Task Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task Logout(string id)
        {
            throw new NotImplementedException();
        }

        public Task Register(User user)
        {
            throw new NotImplementedException();
        }

        public Task<long> updateUserDetails(User user, string id)
        {
            throw new NotImplementedException();
        }
    }
}