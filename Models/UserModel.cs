using System.ComponentModel.DataAnnotations;

namespace JWTASPNetCore.Models
{
    public class UserModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public string ErrorLoginMessage { get; set; }
    }
}
