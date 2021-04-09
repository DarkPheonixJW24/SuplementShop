namespace SuplementShop.Application.Requests
{
    using System.ComponentModel.DataAnnotations;

    public class LogInRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
