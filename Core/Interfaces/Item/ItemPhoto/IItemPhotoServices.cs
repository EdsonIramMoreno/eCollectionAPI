using Core.DTO;
using Core.DTO.Item.ItemPhoto;

namespace Core.Interfaces.Item.ItemPhoto
{
    public interface IItemPhotoServices
    {
        public Task<ResponseDTO> InsertPhoto(ItemPhotoInsertDTO itemPhoto);
        public Task<returnItemPhotoDTO> getAllItemPhotos(int itemId);
        public Task<returnItemPhotoDTO> getItemPhotosById(int itemId, int photoId);
        public Task<ResponseDTO> DeletePhoto(int itemPhotoId);
    }
}
