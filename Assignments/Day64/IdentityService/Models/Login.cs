using Microsoft.AspNetCore.Identity;

namespace IdentityService.Models
{
    public class Login
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string PasswordHash { get; set; }
    }
}
