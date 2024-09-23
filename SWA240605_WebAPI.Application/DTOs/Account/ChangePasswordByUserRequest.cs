namespace SWA240605_WebAPI.Application.DTOs.Account
{
    public class ChangePasswordByUserRequest
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
    }
}
