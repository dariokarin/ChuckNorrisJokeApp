
using ChuckNorrisJokeApp.Data;
using ChuckNorrisJokeApp.Models;
using ChuckNorrisJokeApp.Services.Interface;

namespace ChuckNorrisJokeApp.Services
{
    public class UserService:IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> AddUser(User user)
        {
            var existingUser = await GetUserByEmail(user.Email);
            if (existingUser == null)
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("User already exists");
            }

            return user;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _context.Users.FindAsync(email);
            return user;
        }
    }
}
