using MediatR;
using Microsoft.AspNetCore.Mvc;
using SWA240605_WebAPI.Application.Interfaces;

namespace SWA240605.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseAPIController : ControllerBase
    {
        #region " constructor "

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountService"></param>
        public BaseAPIController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        #endregion

        #region " definitions "
        #endregion

        #region " properties "

        private IMediator? _mediator;
        protected IMediator? mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        // for getting current user info
        private IAccountService _accountService;
        protected IAccountService AccountService => _accountService;

        #endregion

        #region " methods "
        #endregion
    }
}
