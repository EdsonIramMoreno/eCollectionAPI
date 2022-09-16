using Core.DTO.Item.ItemPhoto;
using Core.DTO;
using Core.DTO.User;
using Core.Interfaces.User;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/user")] //https://localhost:7001/api/user/
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices services;

        public UserController(IUserServices services)
        {
            this.services = services;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(UserLoginDTO loginDTO)
        {
            var response = await services.LoginIn(loginDTO);

            if (response == null)
            {
                return StatusCode(404, new ErrorDTO
                {
                    message = "The category catalog was not found."
                });
            }

            return StatusCode(200, response);
        }

        [HttpPost("signin")]
        public async Task<ActionResult> SignIn(UserSignInDTO userInfo)
        {
            var response = await services.SignIn(userInfo);

            if (response == null)
            {
                return StatusCode(404, new ErrorDTO
                {
                    message = "The category catalog was not found."
                });
            }

            return StatusCode(200, response);
        }

        [HttpPut("updateUser")]
        public async Task<ActionResult> UserUpdateInfo(UserInfoDTO user)
        {
            var response = await services.UserUpdateInfo(user);

            if (response == null)
            {
                return StatusCode(404, new ErrorDTO
                {
                    message = "The category catalog was not found."
                });
            }

            return StatusCode(200, response);
        }

        [HttpPut("updatePhoto")]
        public async Task<ActionResult> UserUpdatePhotoInfo(UserUpdatePhotoDTO userPhoto)
        {
            var response = await services.UserUpdatePhotoInfo(userPhoto);

            if (response == null)
            {
                return StatusCode(404, new ErrorDTO
                {
                    message = "The category catalog was not found."
                });
            }

            return StatusCode(200, response);
        }
    }
}
