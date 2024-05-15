using K16231MilkWebAPI.Constants;
using K16231MilkWebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace K16231MilkWebAPI.Controllers
{
    [ApiController]
    public class TestController : BaseController<TestController>
    {
        private readonly ITestService _testService;

        public TestController(ILogger<TestController> logger, ITestService testService) : base(logger)
        {
            _testService = testService;
        }

        [AllowAnonymous]
        [HttpGet(ApiEndPointConstant.Test.TestEndpoint)]
        public async Task<IActionResult> Test()
        {
            var res = await _testService.Test();
            return Ok(res);
        }
    }
}
