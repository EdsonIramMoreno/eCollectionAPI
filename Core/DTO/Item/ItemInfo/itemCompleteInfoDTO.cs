using System.Data.SqlTypes;

namespace Core.DTO.Item.ItemInfo
{
    public class itemCompleteInfoDTO
    {
        public int itemId { get; set; }
        public string itemName { get; set; }
        public string itemDescription { get; set; }
        public decimal marketPrice { get; set; }
        public decimal acquiredPrice { get; set; }
        public string itemCover { get; set; }
        public List<string> itemPhotos { get; set; }
    }
}
