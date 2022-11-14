using Microsoft.AspNetCore.Http;

namespace Core.DTO.User
{
    public class UserUpdatePhotoDTO
    {
        public string userId { get; set; }
        public IFormFile userPhoto { get; set; }
    }
}
