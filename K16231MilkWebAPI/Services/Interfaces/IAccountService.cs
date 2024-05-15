using K16231MilkWebAPI.Payload.Request.Authentication;
using K16231MilkWebAPI.Payload.Response.Authentication;

namespace K16231MilkWebAPI.Services.Interfaces
{
    public interface IAccountService
    {
        public Task<LoginResponse> Login(LoginRequest loginRequest);
    }
}
