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

        public async Task<returnUserDTO> SignIn(UserSignInDTO userMod)
        {
            try
            {
                // 1.0 Obtener información del Usuario
                UserInfoDTO userInfo = await userRepository.SignIn(userMod);

                // 2.0 Retornar Listado
                return new returnUserDTO
                {
                    status = 200,
                    response = "The user has been created succesfully",
                    errors = null,
                    userInfo = userInfo
                };
            }
            catch (Exception ex)
            {
                return new returnUserDTO
                {
                    status = 500,
                    response = "One or more mistakes where found in the consult",
                    errors = new List<ErrorDTO> { new ErrorDTO { message = ex.Message, stackTrace = ex.StackTrace } },
                    userInfo = null
                };
            }
        }
            

        public async Task<returnUserDTO> LoginIn(UserLoginDTO loginDTO)
        {
            try
            {
                // 1.0 Obtener información del Usuario
                UserInfoDTO userInfo = await userRepository.LoginIn(loginDTO);

                // 2.0 Retornar Listado
                return new returnUserDTO
                {
                    status = 200,
                    response = "The user has logged in succesfully",
                     
                    errors = null,
                    userInfo = userInfo
                };
            }
            catch (Exception ex)
            {
                return new returnUserDTO
                {
                    status = 500,
                    response = "One or more mistakes where found in the consult",
                    errors = new List<ErrorDTO> { new ErrorDTO { message = ex.Message, stackTrace = ex.StackTrace } },
                    userInfo = null
                };
            }
        }

        public async Task<returnUserDTO> UserUpdateInfo(UserInfoDTO user)
        {
            try
            {
                // 1.0 Obtener información del Usuario
                UserInfoDTO userInfo = await userRepository.UserUpdateInfo(user);

                // 2.0 Retornar Listado
                return new returnUserDTO
                {
                    status = 200,
                    response = "The user has been updated succesfully",

                    errors = null,
                    userInfo = userInfo
                };
            }
            catch (Exception ex)
            {
                return new returnUserDTO
                {
                    status = 500,
                    response = "One or more mistakes where found in the consult",
                    errors = new List<ErrorDTO> { new ErrorDTO { message = ex.Message, stackTrace = ex.StackTrace } },
                    userInfo = null
                };
            }
        }

        public async Task<returnUserDTO> UserUpdatePhotoInfo(UserUpdatePhotoDTO userUpdate)
        {
            try
            {
                // 1.0 Obtener información del Usuario
                UserInfoDTO userInfo = await userRepository.UserUpdatePhotoInfo(userUpdate);

                // 2.0 Retornar Listado
                return new returnUserDTO
                {
                    status = 200,
                    response = "The user photo has been updated succesfully",

                    errors = null,
                    userInfo = userInfo
                };
            }
            catch (Exception ex)
            {
                return new returnUserDTO
                {
                    status = 500,
                    response = "One or more mistakes where found in the consult",
                    errors = new List<ErrorDTO> { new ErrorDTO { message = ex.Message, stackTrace = ex.StackTrace } },
                    userInfo = null
                };
            }
        }

        public Task<ResponseDTO> UserUpdatePwdInfo(UserUpdatePasswordDTO userUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
