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

        public async Task<returnItemPhotoDTO> getAllItemPhotos(int itemId)
        {
            try
            {
                // 1 Get CategoryModList
                var photoMods = await photoRepository.getAllItemPhotos(itemId);

                List<ItemPhotoDisplayDTO> photos = new List<ItemPhotoDisplayDTO>();

                // 2 Map MOD to DTO
                foreach (var photo in photoMods)
                {
                    photos.Add(ItemPhotoMapper.mapMODtoDTO(photo));
                }


                // 3 Return "returnCategoryDTO"
                if (photos.Count <= 0)
                    return new returnItemPhotoDTO
                    {
                        status = 404,
                        response = "ItemPhotos was NOT found.",
                        errors = null,
                        itemPhotos = null
                    };

                return new returnItemPhotoDTO
                {
                    status = 200,
                    response = "ItemPhotos was found.",
                    errors = null,
                    itemPhotos = photos
                };
            }
            catch (Exception ex)
            {
                return new returnItemPhotoDTO
                {
                    status = 500,
                    response = "One or more errors happend in the search.",
                    errors = new List<ErrorDTO> { new ErrorDTO { message = ex.Message, stackTrace = ex.StackTrace } },
                    itemPhotos = null
                };
            }
        }

        public async Task<returnItemPhotoDTO> getItemPhotosById(int itemId, int photoId)
        {
            try
            {
                // 1 Get CategoryModList
                var photoMods = await photoRepository.getItemPhotosById(itemId, photoId);

                List<ItemPhotoDisplayDTO> photos = new List<ItemPhotoDisplayDTO>();

                // 2 Map MOD to DTO
                    photos.Add(ItemPhotoMapper.mapMODtoDTO(photoMods));


                // 3 Return "returnCategoryDTO"
                if (photos.Count <= 0)
                    return new returnItemPhotoDTO
                    {
                        status = 404,
                        response = "ItemPhotos was NOT found.",
                        errors = null,
                        itemPhotos = null
                    };

                return new returnItemPhotoDTO
                {
                    status = 200,
                    response = "ItemPhotos was found.",
                    errors = null,
                    itemPhotos = photos
                };
            }
            catch (Exception ex)
            {
                return new returnItemPhotoDTO
                {
                    status = 500,
                    response = "One or more errors happend in the search.",
                    errors = new List<ErrorDTO> { new ErrorDTO { message = ex.Message, stackTrace = ex.StackTrace } },
                    itemPhotos = null
                };
            }
        }

        public async Task<ResponseDTO> InsertPhoto(ItemPhotoInsertDTO itemPhoto)
        {
            try
            {
                // 1.0 Obtener información del Usuario
                await photoRepository.InsertPhoto(itemPhoto);

                // 2.0 Retornar Listado
                return new ResponseDTO
                {
                    status = 200,
                    response = "The item photo has been created succesfully",
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
    }
}
