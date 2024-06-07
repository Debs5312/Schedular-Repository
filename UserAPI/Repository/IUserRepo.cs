using Models.API.UserAPI;

namespace UserAPI.Repository
{
    public interface IUserRepo
    {
        Task<List<User>> getAllUsers();
        Task<User> getSingleUser(string id);
        Task Register(User user);
        Task<long> updateUserDetails(User user, string id);
        Task<bool> deleteUser(string id);

        Task Login(string email, string password);

        Task Logout(string id);

        
    }
}