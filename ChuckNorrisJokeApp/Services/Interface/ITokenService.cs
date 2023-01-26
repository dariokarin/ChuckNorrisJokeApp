using ChuckNorrisJokeApp.Models;

namespace ChuckNorrisJokeApp.Services.Interface
{
    public interface ITokenService
    {
        Task<string> CreateToken(User user);
    }
}
