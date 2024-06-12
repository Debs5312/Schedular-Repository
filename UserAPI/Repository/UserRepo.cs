using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Models.API.UserAPI;
using MongoDB.Driver;
using UserAPI.DBConnections;

namespace UserAPI.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly IMongoCollection<User> _playlistCollection;

        public UserDBContext _dbContext { get; }

        public UserRepo(IOptions<DBSettings> mongoDBSettings, UserDBContext dBContext)
        {
            _dbContext = dBContext;

            // MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            // IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            // _playlistCollection = database.GetCollection<User>(mongoDBSettings.Value.CollectionName);
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

        public async Task<User> Register(User user)
        {
            var matchUser = await _dbContext.Users.FirstOrDefaultAsync(item => item.Email == user.Email);
            if(matchUser != null) return matchUser;

            string hashedPassword = HashedPassword(user.Password);
            user.Password = hashedPassword;

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;

        }

        public Task<long> updateUserDetails(User user, string id)
        {
            throw new NotImplementedException();
        }

        private string HashedPassword(string passowrd)
        {
            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: passowrd,
                salt: RandomNumberGenerator.GetBytes(128/8),
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8
            ));

            return hashedPassword;
        }

        private bool VerifyPassword(string passowrd)
        {

            return false;
        }
    }
}