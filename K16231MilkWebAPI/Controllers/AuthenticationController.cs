
using K16231MilkWebAPI.Constants;
using K16231MilkWebAPI.Payload.Request.Authentication;
using K16231MilkWebAPI.Payload.Response;
using K16231MilkWebAPI.Payload.Response.Authentication;
using K16231MilkWebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace K16231MilkWebAPI.Controllers
{
    [ApiController]
    public class AuthenticationController : BaseController<AuthenticationController>
    {
        private readonly IAccountService _accountService;

        public AuthenticationController(ILogger<AuthenticationController> logger, IAccountService accountService)
            : base(logger)
        {
            _accountService = accountService;
        }

        [HttpPost(ApiEndPointConstant.Authentication.LoginEndpoint)]
        [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(UnauthorizedObjectResult))]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            var loginResponse = await _accountService.Login(loginRequest);
            return Ok(loginResponse);
        }
    }
}
