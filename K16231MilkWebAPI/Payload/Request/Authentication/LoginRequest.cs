using System.ComponentModel.DataAnnotations;

namespace K16231MilkWebAPI.Payload.Request.Authentication
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Username is required")]
        public string Emails { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
