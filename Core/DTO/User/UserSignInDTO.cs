using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Core.DTO.User
{
    public class UserSignInDTO
    {
        [Required]
        [StringLength(30, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 5)]
        public string userName { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 5)]
        public string userLastName { get; set; }


        [Required]
        [EmailAddress]
        [StringLength(50, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 10)]
        public string userEmail { get; set; }



        [Required]
        [StringLength(20, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 8)]
        public string pwd { get; set; }

        [Required(ErrorMessage = "{0} is a required field.")]
        public IFormFile userPhoto { get; set; }

        [Required(ErrorMessage = "{0} is a required field.")]
        public int fk_loginTypeId { get; set; }
    }
}
