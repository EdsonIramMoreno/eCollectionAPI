namespace Core.DTO.User
{
    public class returnUserDTO
    {
        public int status { get; set; }
        public string response { get; set; }
        public List<ErrorDTO> errors { get; set; }
        public UserInfoDTO userInfo { get; set; }
    }
}
