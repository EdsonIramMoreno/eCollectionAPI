using Core.DTO;
using Core.DTO.Collection;
using Core.DTO.User;
using Core.Interfaces.Collection;
using Infrastructure.Repositories.Collection;
using Infrastructure.Repositories.User;

namespace API.Application
{
    public class CollectionServices : ICollectionServices
    {
        private readonly ICollectionRepository collectionRepository;

        public CollectionServices(ICollectionRepository collectionRepository)
        {
            this.collectionRepository = collectionRepository;
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
    }
}
