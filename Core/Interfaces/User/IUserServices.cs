using Core.DTO;
using Core.DTO.User;

namespace Core.Interfaces.User
{
    public interface IUserServices
    {
        public Task<UserInfoDTO> LoginIn(UserLoginDTO loginDTO);
        public Task<UserInfoDTO> SignIn(UserSignInDTO userMod);
        public Task<UserInfoDTO> UserUpdateInfo(UserInfoDTO user);
        public Task<UserInfoDTO> UserUpdatePhotoInfo(UserUpdatePhotoDTO userUpdate);
        public Task<ResponseDTO> UserUpdatePwdInfo(UserUpdatePasswordDTO userUpdate);
    }
}
