using ChuckNorrisJokeApp.Models;

namespace ChuckNorrisJokeApp.Services.Interface
{
    public interface IUserService
    {
        Task<User> AddUser(User user);
        Task<User> GetUserByEmail(string email);

    }
}
