using Microsoft.AspNetCore.Http;

namespace Core.DTO.Item.ItemPhoto
{
    public class ItemPhotoInsertDTO
    {
        public int fk_itemId { get; set; }
        public IFormFile itemPhoto { get; set; }
    }
}
