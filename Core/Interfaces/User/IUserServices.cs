using Core.DTO;
using Core.DTO.User;
using Core.Entities.User;

namespace Core.Interfaces.User
{
    public interface IUserServices
    {
        public Task<returnUserDTO> LoginIn(UserLoginDTO loginDTO);
        public Task<returnUserDTO> SignIn(UserSignInDTO userMod);
        public Task<returnUserDTO> UserUpdateInfo(UserInfoDTO user);
        public Task<returnUserDTO> UserUpdatePhotoInfo(UserUpdatePhotoDTO userUpdate);
        public Task<ResponseDTO> UserUpdatePwdInfo(UserUpdatePasswordDTO userUpdate);
    }
}
