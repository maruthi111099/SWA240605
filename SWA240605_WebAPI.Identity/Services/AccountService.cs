using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SWA240605_WebAPI.Application.DTOs;
using SWA240605_WebAPI.Application.DTOs.Account;
using SWA240605_WebAPI.Application.Enums;
using SWA240605_WebAPI.Application.Exceptions;
using SWA240605_WebAPI.Application.Interfaces;
using SWA240605_WebAPI.Application.Wrappers;
using SWA240605_WebAPI.Domain.Settings;
using SWA240605_WebAPI.Identity.Helpers;
using SWA240605_WebAPI.Identity.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;


namespace SWA240605_WebAPI.Identity.Services
{
    public class AccountService : IAccountService
    {
        #region " definitions "

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailService _emailService;
        private readonly JWTSetting _jwtSettings;
        private readonly IDateTimeService _dateTimeService;

        #endregion

        #region " constructor "

        public AccountService(UserManager<ApplicationUser> userManager,
                              RoleManager<IdentityRole> roleManager,
                              IOptions<JWTSetting> jwtSettings,
                              IDateTimeService dateTimeService,
                              SignInManager<ApplicationUser> signInManager,
                              IEmailService emailService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtSettings = jwtSettings.Value;
            _dateTimeService = dateTimeService;
            _signInManager = signInManager;
            this._emailService = emailService;
        }

        #endregion

        #region " registration "

        public Task<APIResponse<bool>> IsRegistered(string userName)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.UserName == userName);
            return Task.FromResult(new APIResponse<bool>(user == null));
        }

        public async Task<APIResponse<string>> RegisterAsync(RegisterRequest request, string? origin, UserRoles role)
        {
            var userWithSameUserName = await _userManager.FindByNameAsync(request.UserName);
            if (userWithSameUserName != null)
            {
                throw new UserNameAlreadyExistsException($"Username '{request.UserName}' already exists.");
            }
            var user = new ApplicationUser
            {
                Email = request.Email,
                Name = request.Name,
                PhoneNumber = request.UserName,
                UserName = request.UserName,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, GetValidPassword(request.Password));
            if (result.Succeeded)
            {
                try
                {
                    await _userManager.AddToRoleAsync(user, role.ToString());
                    return new APIResponse<string>("Successfully Registered.");
                    //await _emailService.SendAsync(new Application.DTOs.Email.EmailRequest() { From = "iyyappan@avia.co.in", To = user.Email, Body = $"Please confirm your account by visiting this URL <br><br> {emailToken}  <br><br> sms Token - {smsToken}", Subject = $"Confirm Registration - {user.PhoneNumber}" });
                    ////TODO: Attach Email Service here and configure it via appsettings
                    //return new Response<string>(user.Id, message: $"User Registered. Please confirm your account.<br><br> email Token - {emailToken}. <br><br>sms Token - {smsToken}");
                    //return new Response<string>(user.Id, message: $"User Registered. Your Date of birth will be your password");
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                throw new APIException($"{result.Errors.ToString()}");
            }
        }

        #endregion

        #region " authentication "

        public async Task<APIResponse<AuthenticationResponse>> AuthenticateAysnc(AuthenticationRequest request, string IPAddress)
        {
            ApplicationUser user;
            user = await _userManager.FindByNameAsync(request.UserName);

            if (user == null)
            {
                throw new APIException($"Invalid User Name {request.UserName}.");
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, GetValidPassword(request.Password), false, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                throw new APIException($"Invalid Credentials for '{request.UserName}'.");
            }
            if (!user.EmailConfirmed)
            {
                //_userManager.ConfirmEmailAsync(user, )
                throw new APIException($"Account not Confirmed for '{request.UserName}'.");
            }
            JwtSecurityToken jwtSecurityToken = await GenerateJWToken(user);
            AuthenticationResponse response = new AuthenticationResponse();
            response.Id = user.Id;
            response.JWToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            response.Email = user.Email;
            response.UserName = user.UserName;
            var rolesList = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
            response.Roles = rolesList.ToList();
            response.IsVerified = user.EmailConfirmed;
            var refreshToken = GenerateRefreshToken(IPAddress);
            response.RefreshToken = refreshToken.Token;
            return new APIResponse<AuthenticationResponse>(response, $"Authenticated {user.UserName}");
        }

        private async Task<JwtSecurityToken> GenerateJWToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim("roles", roles[i]));
            }

            string ipAddress = IPHelper.GetIPAddress();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id),
                new Claim("ip", ipAddress),
                new Claim("uno", user.UserName),
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }

        private string RandomTokenString()
        {
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                byte[] randomBytes = new byte[40];
                rng.GetBytes(randomBytes);
                return Convert.ToBase64String(randomBytes);
            }
            // convert random bytes to hex string
        }

        private RefreshToken GenerateRefreshToken(string ipAddress)
        {
            return new RefreshToken
            {
                Token = RandomTokenString(),
                Expires = DateTime.UtcNow.AddDays(7),
                Created = DateTime.UtcNow,
                CreatedByIP = ipAddress
            };
        }

        #endregion

        #region " verification "

        #region " mobile verification "

        private async Task<string> GetPhoneVerificationCodeAsync(ApplicationUser user)
        {
            FourDigitTokenProvider fdtp = new FourDigitTokenProvider();
            return await fdtp.GenerateAsync("4DigitPhone", _userManager, user);
        }

        public async Task<APIResponse<string>> SendVerificationSMS(string userName, string origin)
        {
            ApplicationUser user = await _userManager.FindByNameAsync(userName);
            if (user == null) throw new Exception("No such phone no. registered.");

            var code = await GetPhoneVerificationCodeAsync(user);
            await _emailService.SendAsync(new EmailRequest() { From = "iyyappan@avia.co.in", To = user.Email, Body = $"Your mobile verification OTP code is {code}. Code is valid for 10 minutes only. one time use. Please DO NOT share this OTP with anyone.", Subject = $"Mobile Confirmation - {user.PhoneNumber}" });
            return new APIResponse<string>("SMS Send");
        }

        public async Task<APIResponse<string>> SendVerificationSMS(ApplicationUser user, string origin)
        {
            try
            {
                FourDigitTokenProvider fdtp = new FourDigitTokenProvider();
                var code = await fdtp.GenerateAsync("4DigitPhone", _userManager, user);
                await _emailService.SendAsync(new EmailRequest() { From = "iyyappan@avia.co.in", To = user.Email, Body = $"Your mobile verification OTP code is {code}. Code is valid for 10 minutes only. one time use. Please DO NOT share this OTP with anyone.", Subject = $"Mobile Confirmation - {user.PhoneNumber}" });
                return new APIResponse<string>("SMS Send");
            }
            catch (Exception ex)
            {
                throw new APIException(ex.Message);
            }
        }

        private async Task<bool> ValidatePhoneVerificationCodeAsync(ApplicationUser user, string code)
        {
            FourDigitTokenProvider fdtp = new FourDigitTokenProvider();
            return await fdtp.ValidateAsync("4DigitPhone", code, _userManager, user);
        }

        public async Task<APIResponse<string>> ConfirmPhoneByUserNameAsync(string userName, string code)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(userName);
                bool isValid = await ValidatePhoneVerificationCodeAsync(user, code);
                if (isValid)
                {
                    user.PhoneNumberConfirmed = true;
                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        await SetNewPasswordAsync(user, "ChangeMe@124");

                        string oldPassword = "ChangeMe@124";
                        string newPassword = GetValidPassword(code);
                        var r2 = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
                        return new APIResponse<string>(user.Id, message: $"Account Confirmed for {user.PhoneNumber}.");
                    }
                    else
                        throw new Exception($"Verification Successful, but unable to update. Contact our support team");
                }
                else
                {
                    throw new Exception($"Invalid / Expired Phone Verification Code, try again...");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occured - {ex.Message} while confirming {userName}.");
            }
        }

        #endregion

        #region " email verification "

        private async Task<string> GetEmailVerificationCodeAsync(ApplicationUser user)
        {
            FourDigitTokenProvider fdtp = new FourDigitTokenProvider();
            return await fdtp.GenerateAsync("4DigitEmail", _userManager, user);
        }

        public async Task<APIResponse<string>> SendVerificationEmail(string userName, string emailId, string origin)
        {
            try
            {
                ApplicationUser? user = await Task.Run(() => _userManager.Users.FirstOrDefault(u => u.UserName == userName));
                if (user == null) throw new Exception("Invalid Device... No Such device registered.");
                if (user.Email == emailId && user.EmailConfirmed) throw new Exception($"Invalid Email. Email {emailId} already registered.");

                var code = await GetEmailVerificationCodeAsync(user);
                await _emailService.SendAsync(new Application.DTOs.EmailRequest() { From = "iyyappan@avia.co.in", To = emailId, Body = $"Your e-mail verification OTP code is {code}. Code is valid for 10 minutes only. one time use. Please DO NOT share this OTP with anyone.", Subject = $"Email Confirmation - {emailId}" });
                return new APIResponse<string>(code);
            }
            catch (Exception ex)
            {
                throw new APIException($"Error occured {ex.Message} while sending verification email to {emailId}.");
            }
        }

        private async Task<bool> VerifyEmailVerificationCodeAsync(ApplicationUser user, string code)
        {
            FourDigitTokenProvider fdtp = new FourDigitTokenProvider();
            return await fdtp.ValidateAsync("4DigitEmail", code, _userManager, user);
        }

        public async Task<APIResponse<string>> ConfirmEmailAsync(string userName, string emailId, string code)
        {
            try
            {
                var user = await Task.Run(() => _userManager.Users.FirstOrDefault(u => u.UserName == userName));
                if (user == null) throw new Exception("Invalid Device, Device not registered.");
                if (user.Email == emailId && user.EmailConfirmed) throw new Exception("Invalid email Id. Email already registered.");

                var isValid = await VerifyEmailVerificationCodeAsync(user, code);
                if (isValid)
                {
                    user.Email = emailId;
                    user.EmailConfirmed = true;
                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                        return new APIResponse<string>(user.UserName, message: $"Account Confirmed for {emailId}.");
                    else
                        throw new Exception($"Verification Successful, but unable to update. Contact our support team.");
                }
                else
                    throw new APIException($"Invalid / Expired Email Verification Code, try again...");
            }
            catch (Exception ex)
            {
                throw new APIException($"Error occured. {ex.Message} while confirming {emailId}.");
            }
        }

        #endregion

        #endregion

        #region " password "

        #region " password "

        public async Task<APIResponse<string>> ForgotPassword(ForgotPasswordRequest model, string origin)
        {
            var user = await Task.Run(() => _userManager.Users.FirstOrDefault(u => u.UserName == model.UserName));
            if (user == null) throw new Exception($"No such device registered");

            var code = await GetPhoneVerificationCodeAsync(user);
            var emailRequest = new EmailRequest()
            {
                Body = $"Your Pin Code is - {code}. This will expire in 10 mins.",
                To = "iyyappanr@gmail.com",
                Subject = "Reset Pin",
            };
            await _emailService.SendAsync(emailRequest);
            return new APIResponse<string>($"New Pin Code sent to {user.UserName}");
        }

        public async Task<APIResponse<string>> ChangePin(ChangePinRequest model)
        {
            var user = await Task.Run(() => _userManager.Users.FirstOrDefault(u => u.UserName == model.UserName));
            if (user == null) throw new APIException($"No such device is registered.");

            var r2 = await ValidatePhoneVerificationCodeAsync(user, model.PinCode);
            if (!r2)
                throw new Exception("Unable to Reset Pin, invalid pin-code.");

            var r3 = await SetNewPasswordAsync(user, GetValidPassword(model.Pin));
            if (r3.Succeeded)
                return new APIResponse<string>("Pin Resetted.");
            else
                throw new Exception("Unable to Reset password, try again later, else, contact our support team.");
        }

        public async Task<APIResponse<string>> ResetPassword(ResetPasswordRequest request)
        {
            var user = await Task.Run(() => _userManager.Users.FirstOrDefault(u => u.UserName == request.UserName));
            if (user == null) throw new APIException($"No User Name found - {request.UserName}");

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            IdentityResult result = await _userManager.ResetPasswordAsync(user, token, GetValidPassword(request.NewPassword));

            if (result == IdentityResult.Success)
                return new APIResponse<string>("Reset Password is success.");
            else
                throw new Exception($"Unable to reset password, due to {result.ToString()}");
        }

        #endregion

        #region " change password "

        private async Task<APIResponse<string>> ChangePasswordAsync(ApplicationUser user, string oldPassword, string newPassword)
        {
            var result = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
            if (result.Succeeded)
                return new APIResponse<string>("Successfully updated");

            IdentityError error = result.Errors.First();
            throw new Exception($"Code - {error.Code} Description - {error.Description}");
        }

        public async Task<APIResponse<string>> ChangePasswordByDevice(string userName, string oldPassword, string newPassword)
        {
            ApplicationUser? user = await Task.Run(() => _userManager.Users.FirstOrDefault(u => u.UserName == userName));
            if (user == null) throw new Exception("Invalid Device, Contact Support Team.");
            oldPassword = GetValidPassword(oldPassword);
            newPassword = GetValidPassword(newPassword);
            return ChangePasswordAsync(user, oldPassword, newPassword).Result;
        }

        public async Task<APIResponse<string>> ChangePasswordByUserName(string userName, string oldPassword, string newPassword)
        {
            ApplicationUser user = await _userManager.FindByNameAsync(userName);
            if (user == null) throw new Exception("Invalid User Name, no such user name found.");
            oldPassword = GetValidPassword(oldPassword);
            newPassword = GetValidPassword(newPassword);
            return ChangePasswordAsync(user, oldPassword, newPassword).Result;
        }

        #endregion

        #region " private methods "

        private string GetValidPassword(string p)
        {
            return $"{p}_DVs1@";
        }

        private async Task<IdentityResult> SetNewPasswordAsync(ApplicationUser user, string newPassword)
        {
            await _userManager.RemovePasswordAsync(user);
            return await _userManager.AddPasswordAsync(user, newPassword);
        }

        #endregion

        #endregion

        #region " queries "

        public async Task<APIResponse<string>> GetUserAsync(string userId)
        {
            var account = await _userManager.FindByIdAsync(userId);
            if (account == null) throw new APIException($"No accounts, Invalid Session...");
            return new APIResponse<string>(account.UserName);
        }

        public async Task<APIResponse<string>> GetUserByUserNameAsync(string userName)
        {
            var account = await _userManager.FindByNameAsync(userName);
            if (account == null) throw new APIException($"No account registered with this mobile no, Invalid Mobile No...");
            return new APIResponse<string>(account.UserName);
        }

        public async Task<APIResponse<string>> GetUserByDeviceAsync(string userName)
        {
            ApplicationUser? user = await Task.Run(() => _userManager.Users.FirstOrDefault(u => u.UserName == userName));
            if (user == null) throw new APIException($"No account registered with this mobile no, Invalid Mobile No...");
            return new APIResponse<string>(user.UserName);
        }

        #endregion
    }
}
