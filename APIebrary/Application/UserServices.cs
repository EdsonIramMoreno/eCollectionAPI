using Core.DTO;
using Core.DTO.User;
using Core.Entities.User;
using Core.Interfaces.User;

namespace API.Application
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository userRepository;

        public UserServices(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<UserInfoDTO> SignIn(UserSignInDTO userMod)
        {
            try
            {
                // 1.0 Obtener información del Usuario
                UserInfoDTO userInfo = await userRepository.SignIn(userMod);

                // 2.0 Retornar Listado
                return userInfo;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception: " + ex.Message + " " + ex.StackTrace);
            }
        }
            

        public async Task<UserInfoDTO> LoginIn(UserLoginDTO loginDTO)
        {
            try
            {
                // 1.0 Obtener información del Usuario
                UserInfoDTO userInfo = await userRepository.LoginIn(loginDTO);

                // 2.0 Retornar Listado
                return userInfo;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception: " + ex.Message + " " + ex.StackTrace);
            }
        }

        public async Task<UserInfoDTO> UserUpdateInfo(UserInfoDTO user)
        {
            try
            {
                // 1.0 Obtener información del Usuario
                UserInfoDTO userInfo = await userRepository.UserUpdateInfo(user);

                // 2.0 Retornar Listado
                return userInfo;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception: " + ex.Message + " " + ex.StackTrace);
            }
        }

        public async Task<UserInfoDTO> UserUpdatePhotoInfo(UserUpdatePhotoDTO userUpdate)
        {
            try
            {
                // 1.0 Obtener información del Usuario
                UserInfoDTO userInfo = await userRepository.UserUpdatePhotoInfo(userUpdate);

                // 2.0 Retornar Listado
                return userInfo;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception: " + ex.Message + " " + ex.StackTrace);
            }
        }

        public Task<ResponseDTO> UserUpdatePwdInfo(UserUpdatePasswordDTO userUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
