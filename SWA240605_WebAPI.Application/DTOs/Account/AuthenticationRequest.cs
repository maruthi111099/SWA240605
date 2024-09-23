namespace SWA240605_WebAPI.Application.DTOs.Account
{
    public class AuthenticationRequest
    {
        public string UserCode { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
