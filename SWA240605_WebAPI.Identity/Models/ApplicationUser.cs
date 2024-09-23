using Microsoft.AspNetCore.Identity;
using SWA240605_WebAPI.Application.DTOs.Account;

namespace SWA240605_WebAPI.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; } = string.Empty;
        public List<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
        public bool OwnsToken(string token)
        {
            return this.RefreshTokens?.Find(x => x.Token == token) != null;
        }
    }
}
