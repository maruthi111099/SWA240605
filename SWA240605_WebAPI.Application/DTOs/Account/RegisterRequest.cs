namespace SWA240605_WebAPI.Application.DTOs.Account
{
    public class RegisterRequest
    {
        public string UserCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string PhoneNo { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool? IsAdmin { get; set; }
    }
}
