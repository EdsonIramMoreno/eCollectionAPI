using System.ComponentModel.DataAnnotations;

namespace Core.DTO.User
{
    public class UserUpdatePasswordDTO
    {
        [Required]
        [EmailAddress]
        [StringLength(50, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 10)]
        public string Email { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 8)]
        public string Password { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 8)]
        public string newPassword { get; set; }
    }
}
