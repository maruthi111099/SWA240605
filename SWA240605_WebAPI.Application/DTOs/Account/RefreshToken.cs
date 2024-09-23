using System;

namespace SWA240605_WebAPI.Application.DTOs.Account
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public string Token { get; set; } = string.Empty;
        public DateTime Expires { get; set; }
        public bool IsExpired => DateTime.UtcNow >= Expires;
        public DateTime Created { get; set; }
        public string CreatedByIP { get; set; } = string.Empty;
        public DateTime? Revoked { get; set; }
        public string RevokedByIP { get; set; } = string.Empty;
        public string ReplacedByToken { get; set; } = string.Empty;
        public bool IsActive => Revoked == null && IsExpired;
    }
}
