namespace SWA240605_WebAPI.Application.DTOs.Account
{
    public class ChangePinRequest
    {
        public string UserName { get; set; } = string.Empty;
        public string PinCode { get; set; } = string.Empty;
        public string Pin { get; set; } = string.Empty;
    }
}
