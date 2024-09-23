using Microsoft.AspNetCore.Mvc;
using SWA240605_WebAPI.Application.Interfaces;
using System.Diagnostics;

namespace SWA240605.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetaController : BaseAPIController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("/info")]
        public ActionResult<string> Info()
        {
            var assembly = typeof(Program).Assembly;

            var lastUpdated = System.IO.File.GetLastWriteTime(assembly.Location);
            var version = FileVersionInfo.GetVersionInfo(assembly.Location).ProductVersion;

            return Ok($"Version: {version}, Last Updated: {lastUpdated}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountService"></param>
        public MetaController(IAccountService accountService) : base(accountService)
        { }
    }
}
