using System.ComponentModel.DataAnnotations;

namespace SuperMarketManagement.Models
{
    public class Login
    {
        public string UserId { get; set; }
        [Required(ErrorMessage = "Password id Required")]
        [Compare("Password",ErrorMessage="Password doesn't match")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
