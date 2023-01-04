using Core.DTO;
using Core.DTO.Item.ItemPhoto;

namespace Core.Interfaces.Item.ItemPhoto
{
    public interface IItemPhotoServices
    {
        public Task<int> InsertPhoto(ItemPhotoInsertDTO itemPhoto);
        public Task<ItemPhotoDisplayDTO> getItemPhotosById(int itemId, int photoId);
        public Task<ResponseDTO> DeletePhoto(int itemPhotoId);
    }
}
