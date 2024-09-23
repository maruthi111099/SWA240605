using SWA240605_WebAPI.Application.Interfaces;
using System.Security.Claims;

namespace SWA240605.Services
{
    public class AuthenticatedUserService : IAuthenticatedUserService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        public AuthenticatedUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserCode = httpContextAccessor.HttpContext?.User?.FindFirstValue("UNO");
        }

        /// <summary>
        /// 
        /// </summary>
        public string? UserCode { get; set; }
    }
}
