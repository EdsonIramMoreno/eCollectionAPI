using Microsoft.AspNetCore.Http;

namespace Core.DTO.Item.ItemInfo
{
    public class itemInsertInfoDTO
    {
        public string itemName { get; set; }
        public string itemDescription { get; set; }
        public decimal marketPrice { get; set; }
        public decimal acquiredPrice { get; set; }
        public IFormFile itemCover { get; set; }
        public int fk_collectionId { get; set; }
    }
}
