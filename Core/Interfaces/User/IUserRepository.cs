using Core.DTO;
using Core.DTO.User;

namespace Core.Interfaces.User
{
    public interface IUserRepository
    {
        public Task<UserInfoDTO> LoginIn(UserLoginDTO loginDTO);
        public Task<UserInfoDTO> SignIn(UserSignInDTO luserMod);
        public Task<UserInfoDTO> UserUpdateInfo(UserInfoDTO user);
        public Task<UserInfoDTO> UserUpdatePhotoInfo(UserUpdatePhotoDTO userUpdate);
        public Task UserUpdatePwdInfo(UserUpdatePasswordDTO userUpdate);
    }
}
