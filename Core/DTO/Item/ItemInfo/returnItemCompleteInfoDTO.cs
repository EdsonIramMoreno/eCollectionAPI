namespace Core.DTO.Item.ItemInfo
{
    public class returnItemCompleteInfoDTO
    {
        public int status { get; set; }
        public string response { get; set; }
        public List<ErrorDTO> errors { get; set; }
        public List<itemCompleteInfoDTO> itemInfo { get; set; }
    }
}
