using Microsoft.AspNetCore.Mvc;
using SWA240605_WebAPI.Application.DTOs.Account;
using SWA240605_WebAPI.Application.Enums;
using SWA240605_WebAPI.Application.Interfaces;
using SWA240605_WebAPI.Application.Wrappers;

namespace SWA240605.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseAPIController
    {

        #region " constructor "

        public AccountController(IAccountService accountService) : base(accountService)
        {
            this._accountService = accountService;
        }

        #endregion

        #region " declarations "

        private readonly IAccountService _accountService;

        #endregion

        #region " authentication "

        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateAsync(AuthenticationRequest request)
        {
            APIResponse<AuthenticationResponse> result = await _accountService.AuthenticateAysnc(request, GenerateIPAddress());
            return Ok(result);
        }

        #endregion

        #region " registration "

        [HttpPost("register-teamleader")]
        public async Task<IActionResult> RegisterAdminAsync(RegisterRequest request)
        {
            string? origin = Request.Headers["origin"];
            return Ok(await _accountService.RegisterAsync(request, origin, UserRoles.Admin));
        }

        [HttpPost("register-client")]
        public async Task<IActionResult> RegisterUserAsync(RegisterRequest request)
        {
            string? origin = Request.Headers["origin"];
            return Ok(await _accountService.RegisterAsync(request, origin, UserRoles.Applicant));
        }

        [HttpPost("register-batchentrymember")]
        public async Task<IActionResult> RegisterSuperAdminAsync(RegisterRequest request)
        {
            string? origin = Request.Headers["origin"];
            return Ok(await _accountService.RegisterAsync(request, origin, UserRoles.SuperAdmin));
        }

        #endregion

        #region " verification "

        #region " email "

        [HttpPost("send-email-confirmation")]
        public async Task<IActionResult> SendEmail(string deviceId, string emailId)
        {
            return Ok(await _accountService.SendVerificationEmail(deviceId, emailId, ""));
        }

        [HttpPost("confirm-email")]
        public async Task<IActionResult> ConfirmEmailAsync([FromQuery] string deviceId, [FromQuery] string emailId, [FromQuery] string code)
        {
            //var origin = Request.Headers["origin"];
            return Ok(await _accountService.ConfirmEmailAsync(deviceId, emailId, code));
        }

        #endregion

        #region " mobile "

        [HttpPost("send-sms")]
        public async Task<IActionResult> SendSMS(string userName)
        {
            return Ok(await _accountService.SendVerificationSMS(userName, ""));
        }

        [HttpPost("confirm-mobile-username")]
        public async Task<IActionResult> ConfirmMobileByUserNameAsync([FromQuery] string userName, [FromQuery] string code)
        {
            return Ok(await _accountService.ConfirmPhoneByUserNameAsync(userName, code));
        }

        #endregion

        #endregion

        #region " password "

        #region " forget password "

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordRequest model)
        {
            return Ok(await _accountService.ForgotPassword(model, Request.Headers["origin"]));
        }

        [HttpPost("Change-Pin")]
        public async Task<IActionResult> ChangePin(ChangePinRequest model)
        {
            return Ok(await _accountService.ChangePin(model));
        }

        #endregion

        #region " change password "
        //[HttpPut("change-password-username")]
        //public async Task<IActionResult> ChangePasswordByUserName(ChangePasswordByUserRequest request)
        //{
        //    await _accountService.ChangePasswordByUserName(request.UserName, request.Password, request.NewPassword);

        //    if (mediator == null) throw new Exception();

        //    return Ok(mediator.Send(new UpdateShouldChangePasswordCommand()
        //    {
        //        UserCode = request.UserName,
        //        ShouldChangePassword = false
        //    }));
        //}

        [HttpPut("change-password-device")]
        public async Task<IActionResult> ChangePasswordByDevice(string deviceId, string oldPassword, string newPassword)
        {
            return Ok(await _accountService.ChangePasswordByDevice(deviceId, oldPassword, newPassword));
        }

        #endregion

        #region " reset password "

        [HttpPut("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordRequest request)
        {
            return Ok(await _accountService.ResetPassword(request));
        }

        #endregion

        #endregion

        #region " get queries "

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserAsync(string userId)
        {
            return Ok(await _accountService.GetUserAsync(userId));
        }

        [HttpGet("{userName}/username")]
        public async Task<IActionResult> GetByUserName(string userName)
        {
            return Ok(await _accountService.GetUserByUserNameAsync(userName));
        }

        [HttpGet("{deviceId}/device")]
        public async Task<IActionResult> GetByDevice(string deviceId)
        {
            return Ok(await _accountService.GetUserByDeviceAsync(deviceId));
        }

        #endregion

        #region " methods "

        private string GenerateIPAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
            {
                if (HttpContext.Connection.RemoteIpAddress == null)
                    throw new Exception("Unable to get the Client IP Address.");

                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            }
        }

        #endregion
    }
}
