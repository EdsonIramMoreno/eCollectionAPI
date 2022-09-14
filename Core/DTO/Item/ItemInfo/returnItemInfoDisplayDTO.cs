using Core.DTO.Category;

namespace Core.DTO.Item.ItemInfo
{
    public class returnItemInfoDisplayDTO
    {
        public int status { get; set; }
        public string response { get; set; }
        public List<ErrorDTO> errors { get; set; }
        public List<itemDisplayInfoDTO> items { get; set; }
    }
}
