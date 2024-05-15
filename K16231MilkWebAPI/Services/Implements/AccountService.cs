using AutoMapper;
using K16231MilkBusiness.Interfaces;
using K16231MilkData.Entity;
using K16231MilkWebAPI.Constants;
using K16231MilkWebAPI.Payload.Request.Authentication;
using K16231MilkWebAPI.Payload.Response.Authentication;
using K16231MilkWebAPI.Services.Interfaces;
using K16231MilkWebAPI.Utils;

namespace K16231MilkWebAPI.Services.Implements
{
    public class AccountService : BaseService<AccountService>, IAccountService
    {
        public AccountService(IUnitOfWork<MilkDbContext> unitOfWork, ILogger<AccountService> logger,
            IMapper mapper, IHttpContextAccessor httpContextAccessor) 
            : base(unitOfWork, logger, mapper, httpContextAccessor)
        {
        }

        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            //Check input
            Account account = await _unitOfWork.GetRepository<Account>()
                .SingleOrDefaultAsync(predicate: a => a.Email.Equals(loginRequest.Emails) &&
                                                      a.Password.Equals(loginRequest.Password));
            if (account == null) throw new BadHttpRequestException(MessageConstant.AuthenticationMessage.IncorrectEmailOrPass);

            //Set response
            LoginResponse response = new LoginResponse(account.AccountId, account.FullName, account.Role);

            //Create Jwt Validation Token
            var token = JwtUtil.GenerateJwtToken(account);
            response.AccessToken = token;
            return response;
        }


    }
}
