using System.ComponentModel.DataAnnotations;

namespace ChuckNorrisJokeApp.Models
{
    public class User
    {
        [Key]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }
    }
}
