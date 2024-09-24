using Microsoft.AspNetCore.Mvc;
using SWA240605_WebAPI.Application.Interfaces;

namespace SWA240605.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : BaseAPIController
    {
        #region " constructor "

        public ApplicantController(IAccountService accountService) : base(accountService)
        {
            _accountService = accountService;
        }

        #endregion

        #region " definitions "

        private readonly IAccountService _accountService;

        #endregion

    }
}
