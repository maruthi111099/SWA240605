using SWA240605_WebAPI.Application.DTOs.Account;
using SWA240605_WebAPI.Application.Enums;
using SWA240605_WebAPI.Application.Wrappers;
using System.Threading.Tasks;

namespace SWA240605_WebAPI.Application.Interfaces
{
    public interface IAccountService
    {
        #region " authentication "

        Task<APIResponse<AuthenticationResponse>> AuthenticateAysnc(AuthenticationRequest request, string IPAddress);

        #endregion

        #region " registration "

        Task<APIResponse<string>> RegisterAsync(RegisterRequest request, string? Origin, UserRoles role);

        #endregion

        #region " verification "

        #region " email verification "

        Task<APIResponse<string>> SendVerificationEmail(string deviceId, string emailId, string origin);
        Task<APIResponse<string>> ConfirmEmailAsync(string deviceId, string emailId, string code);

        #endregion

        #region " mobile verification "

        Task<APIResponse<string>> SendVerificationSMS(string userName, string origin);
        Task<APIResponse<string>> ConfirmPhoneByUserNameAsync(string userName, string code);

        #endregion

        #endregion

        #region " password "

        Task<APIResponse<string>> ForgotPassword(ForgotPasswordRequest model, string origin);
        Task<APIResponse<string>> ChangePin(ChangePinRequest model);
        Task<APIResponse<string>> ChangePasswordByDevice(string deviceId, string oldPassword, string newPassword);
        Task<APIResponse<string>> ChangePasswordByUserName(string userName, string oldPassword, string newPassword);
        Task<APIResponse<string>> ResetPassword(ResetPasswordRequest request);

        #endregion

        #region " get queries "

        Task<APIResponse<string>> GetUserAsync(string userCode);
        Task<APIResponse<string>> GetUserByUserNameAsync(string userName);
        Task<APIResponse<string>> GetUserByDeviceAsync(string deviceId);

        #endregion
    }
}
