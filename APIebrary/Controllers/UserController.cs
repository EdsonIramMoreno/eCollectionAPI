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
        public async Task<ActionResult<returnUserDTO>> Login(UserLoginDTO loginDTO)
        {
            returnUserDTO response = await services.LoginIn(loginDTO);

            return StatusCode(response.status, response);
        }

        [HttpPost("signin")]
        public async Task<ActionResult<returnUserDTO>> SignIn(UserSignInDTO userInfo)
        {
            returnUserDTO response = await services.SignIn(userInfo);

            return StatusCode(response.status, response);
        }

        [HttpPut("updateUser")]
        public async Task<ActionResult<ResponseDTO>> UserUpdateInfo(UserInfoDTO user)
        {
            returnUserDTO response = await services.UserUpdateInfo(user);

            return StatusCode(response.status, response);
        }

        [HttpPut("updatePhoto")]
        public async Task<ActionResult<ResponseDTO>> UserUpdatePhotoInfo(UserUpdatePhotoDTO userPhoto)
        {
            returnUserDTO response = await services.UserUpdatePhotoInfo(userPhoto);

            return StatusCode(response.status, response);
        }
    }
}
