using ApiModels;

namespace ApiRepository
{
    public interface IUserRepository
    {
        Task<bool> Create(User user);
        Task<bool> Delete(int id);
        Task<User> GetUserAsync(string username, string password);
        Task<List<User>> GetUsers();
        Task<User> GetUsers(int id);
        Task<bool> Update(User user);
    }
}