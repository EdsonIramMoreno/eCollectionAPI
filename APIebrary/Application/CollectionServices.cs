using Core.DTO;
using Core.DTO.Category;
using Core.DTO.Collection;
using Core.DTO.User;
using Core.Entities.Item.ItemPhoto;
using Core.Interfaces.Collection;
using Core.Mappers;
using Infrastructure.Repositories.Category;
using Infrastructure.Repositories.Collection;
using Infrastructure.Repositories.Item;
using Infrastructure.Repositories.User;
using Microsoft.AspNetCore.Http;

namespace API.Application
{
    public class CollectionServices : ICollectionServices
    {
        private readonly ICollectionRepository collectionRepository;

        public CollectionServices(ICollectionRepository collectionRepository)
        {
            this.collectionRepository = collectionRepository;
        }

        public async Task<ResponseDTO> CollectionInfoUpdate(CollectionInfoUpdateDTO collection)
        {
            try
            {
                // 1.0 Obtener información del Usuario
                await collectionRepository.CollectionInfoUpdate(collection);

                // 2.0 Retornar Listado
                return new ResponseDTO
                {
                    status = 200,
                    response = "The collection has been updated succesfully",
                    errors = null,
                    entityName = "CollectionInfo"
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO
                {
                    status = 500,
                    response = "One or more mistakes where found in the consult",
                    errors = new List<ErrorDTO> { new ErrorDTO { message = ex.Message, stackTrace = ex.StackTrace } },
                    entityName = "CollectionInfo"
                };
            }
        }

        public async Task<ResponseDTO> CreateCollection(CollectionInfoInsertDTO collectionInfo)
        {
            try
            {
                // 1.0 Obtener información del Usuario
                await collectionRepository.CreateCollection(collectionInfo);

                // 2.0 Retornar Listado
                return new ResponseDTO
                {
                    status = 200,
                    response = "The collection has been created succesfully",
                    errors = null,
                    entityName = "CollectionInfo"
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO
                {
                    status = 500,
                    response = "One or more mistakes where found in the consult",
                    errors = new List<ErrorDTO> { new ErrorDTO { message = ex.Message, stackTrace = ex.StackTrace } },
                    entityName = "CollectionInfo"
                };
            }
        }

        public async Task<ResponseDTO> DeleteCollection(int collectionId)
        {
            try
            {
                // 1.0 Obtener información del Usuario
                await collectionRepository.DeleteCollection(collectionId);

                // 2.0 Retornar Listado
                return new ResponseDTO
                {
                    status = 200,
                    response = "The icollection and its items have been deleted succesfully",
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

        public async Task<CollectionInfoDTO> getCollectionById(int collectionId)
        {
            try
            {
                // 1 Get CategoryModList
                var collectionMod = await collectionRepository.getCollectionById(collectionId);

                var collectionDTO = new CollectionInfoDTO();

                // 2 Map MOD to DTO
                    collectionDTO = CollectionMapper.mapMODtoDTO(collectionMod);

                return collectionDTO;
                
            }
            catch (Exception ex)
            {
                throw new Exception("Exception: " + ex.Message + " " + ex.StackTrace);
            }
        }

        public async Task<List<CollectionInfoDisplayDTO>> getCollectionInfoDisplay(string fk_userId)
        {
            try
            {
                var collectionMod = await collectionRepository.getCollectionInfoDisplay(fk_userId);
                
                var collectionDTO = new List<CollectionInfoDisplayDTO>();

                // 2 Map MOD to DTO
                foreach (var collection in collectionMod)
                {
                    collectionDTO.Add(CollectionMapper.mapDisplayMODtoDTO(collection));
                }

                return collectionDTO;

            }
            catch (Exception ex)
            {
                throw new Exception("Exception: " + ex.Message + " " + ex.StackTrace);
            }
        }
    }
}
