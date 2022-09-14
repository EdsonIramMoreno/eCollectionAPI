namespace Core.DTO
{
    public class ResponseDTO
    {
        public int status { get; set; }
        public string response { get; set; }
        public List<ErrorDTO> errors { get; set; }
        public string entityName { get; set; }
    }
}
