using K16231MilkWebAPI.Enums;
using K16231MilkWebAPI.Utils;

namespace K16231MilkWebAPI.Payload.Response.Authentication
{
    public class LoginResponse
    {
        public string AccessToken { get; set; }
        public int Id { get; set; }
        public string FullName { get; set; }
        public RoleEnum Role { get; set; }

        public LoginResponse(int id, string fullName, string role)
        {
            Id = id;
            FullName = fullName;
            Role = EnumUtil.ParseEnum<RoleEnum>(role);
        }
    }
}
