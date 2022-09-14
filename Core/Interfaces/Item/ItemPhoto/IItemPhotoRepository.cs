using Core.DTO;
using Core.DTO.Item.ItemInfo;
using Core.DTO.Item.ItemPhoto;
using Core.Entities.Item.ItemPhoto;

namespace Core.Interfaces.Item.ItemPhoto
{
    public interface IItemPhotoRepository
    {
        public Task InsertPhoto(ItemPhotoInsertDTO itemPhoto);
        public Task<List<ItemPhotoMod>> getAllItemPhotos(int itemId);
        public Task<ItemPhotoMod> getItemPhotosById(int itemId, int photoId);
        public Task DeletePhoto(int itemPhotoId);
    }
}
