using K16231MilkData.Entity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace K16231MilkWebAPI.Utils
{
    public class JwtUtil
    {
        //public static string GenerateJwtToken(Account account, Tuple<string, Guid> guidClaim)
        //{
        //    IConfiguration configuration = new ConfigurationBuilder()
        //        .AddEnvironmentVariables(EnvironmentVariableConstant.Prefix).Build();
        //    JwtSecurityTokenHandler jwtHandler = new JwtSecurityTokenHandler();
        //    SymmetricSecurityKey secrectKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>(JwtConstant.SecretKey)));
        //    var credentials = new SigningCredentials(secrectKey, SecurityAlgorithms.HmacSha256Signature);
        //    string issuer = configuration.GetValue<string>(JwtConstant.Issuer);
        //    List<Claim> claims = new List<Claim>()
        //{
        //    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
        //    new Claim(JwtRegisteredClaimNames.Sub,account.FullName),
        //    new Claim(ClaimTypes.Role,account.Role),
        //};
        //    if (guidClaim != null) claims.Add(new Claim(guidClaim.Item1, guidClaim.Item2.ToString()));
        //    var expires = account.Role.Name.Equals(RoleEnum.Staff.GetDescriptionFromEnum()) ? DateTime.Now.AddDays(1) : DateTime.Now.AddMinutes(configuration.GetValue<long>(JwtConstant.TokenExpireInMinutes));
        //    var token = new JwtSecurityToken(issuer, null, claims, notBefore: DateTime.Now, expires, credentials);
        //    return jwtHandler.WriteToken(token);
        //}
    }
}
