using AutoMapper;
using K16231MilkBusiness.Interfaces;
using K16231MilkData.Entity;

namespace K16231MilkWebAPI.Services
{
    public interface ITestService
    {
        public Task<string> Test();
    }

    public class TestService : BaseService<TestService>, ITestService
    {
        public TestService(IUnitOfWork<MilkDbContext> unitOfWork, ILogger<TestService> logger, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, logger, mapper, httpContextAccessor)
        {
        }

        public async Task<string> Test()
        {
            //throw new BadHttpRequestException("Test thui á khum cóa gì đeo");
            return "asas";
        }
    }
}
