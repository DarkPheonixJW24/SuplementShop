using System.ComponentModel.DataAnnotations;

namespace SuplementShop.Application.Requests
{
    public class SignUpRequest
    {
        public string FullName { get; set; }


        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
