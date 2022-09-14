using Core.DTO.Category;
using Core.DTO.Item.ItemPhoto;
using Core.Entities.CategoryList;
using Core.Entities.Item.ItemPhoto;

namespace Core.Mappers
{
    public class ItemPhotoMapper
    {
        public static ItemPhotoDisplayDTO mapMODtoDTO(ItemPhotoMod photo)
        {
            return new ItemPhotoDisplayDTO
            {
                itemPhotoId = photo.itemPhotoId,
                itemPhoto = photo.itemPhoto
            };
        }

        public static ItemPhotoMod mapDTOtoMOD(ItemPhotoDisplayDTO photo)
        {
            return new ItemPhotoMod
            {
                itemPhoto = photo.itemPhoto,
                itemPhotoId = photo.itemPhotoId
            };
        }
    }
}
