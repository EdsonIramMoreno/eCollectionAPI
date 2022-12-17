using Core.DTO;
using Core.DTO.Category;
using Core.DTO.Item.ItemPhoto;
using Core.Interfaces.Item.ItemPhoto;
using Core.Mappers;
using Infrastructure.Repositories.Category;
using Infrastructure.Repositories.Item;

namespace API.Application
{
    public class ItemPhotoServices : IItemPhotoServices
    {
        private readonly IItemPhotoRepository photoRepository;

        public ItemPhotoServices(IItemPhotoRepository photoRepository)
        {
            this.photoRepository = photoRepository;
        }

        public async Task<ResponseDTO> DeletePhoto(int itemPhotoId)
        {
            try
            {
                // 1.0 Obtener información del Usuario
                await photoRepository.DeletePhoto(itemPhotoId);

                // 2.0 Retornar Listado
                return new ResponseDTO
                {
                    status = 200,
                    response = "The item photo has been deleted succesfully",
                    errors = null,
                    entityName = "ItemPhoto"
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO
                {
                    status = 500,
                    response = "One or more mistakes where found in the consult",
                    errors = new List<ErrorDTO> { new ErrorDTO { message = ex.Message, stackTrace = ex.StackTrace } },
                    entityName = "ItemPhoto"
                };
            }
        }

        public async Task<ItemPhotoDisplayDTO> getItemPhotosById(int itemId, int photoId)
        {
            try
            {
                // 1 Get CategoryModList
                var photoMods = await photoRepository.getItemPhotosById(itemId, photoId);

                var photo = new ItemPhotoDisplayDTO();

                // 2 Map MOD to DTO
                    photo = ItemPhotoMapper.mapMODtoDTO(photoMods);


                return photo;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception: " + ex.Message + " " + ex.StackTrace);
            }
        }

        public async Task<int> InsertPhoto(ItemPhotoInsertDTO itemPhoto)
        {
            try
            {
                // 1.0 Obtener información del Usuario
                await photoRepository.InsertPhoto(itemPhoto);

                // 2.0 Retornar Listado
                return 200;
            }
            catch (Exception ex)
            {
                return 500;
            }
        }
    }
}
