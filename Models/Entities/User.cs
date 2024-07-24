using Microsoft.AspNetCore.Identity;

namespace StudentsServices.Models.Entities
{
    public class User : IdentityUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }  // Use PasswordHash for ASP.NET Core Identity
        public string Role { get; set; }
        public string RefreshToken { get; set; }  // Add this if you are using refresh tokens
        public DateTime RefreshTokenExpiryTime { get; set; }  // Add this if you are using refresh tokens
    }
}