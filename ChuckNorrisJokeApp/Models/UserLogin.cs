using System.ComponentModel.DataAnnotations;

namespace ChuckNorrisJokeApp.Models
{
    public class UserLogin
    {
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
