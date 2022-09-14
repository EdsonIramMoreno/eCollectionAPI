using Core.DTO;
using Core.DTO.rel_Category_Collection;
using Core.Interfaces.rel_Category_Collection;
using Infrastructure.Repositories.Item;

namespace API.Application
{
    public class Cat_CollectionServices : ICat_CollectionServices
    {
        private readonly ICat_CollectionRepository collectionRepository;

        public Cat_CollectionServices(ICat_CollectionRepository collectionRepository)
        {
            this.collectionRepository = collectionRepository;
        }

        public async Task<ResponseDTO> insertRel(rel_Cat_Collection_DTO rel_Cat)
        {
            try
            {
                // 1.0 Obtener información del Usuario
                foreach(var rel in rel_Cat.fk_categoryId){ 
                    await collectionRepository.insertRel(rel_Cat.fk_collectionId, rel);
                }

                // 2.0 Retornar Listado
                return new ResponseDTO
                {
                    status = 200,
                    response = "The relations have been created succesfully",
                    errors = null,
                    entityName = "rel_Category_Collection"
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO
                {
                    status = 500,
                    response = "One or more mistakes where found in the consult",
                    errors = new List<ErrorDTO> { new ErrorDTO { message = ex.Message, stackTrace = ex.StackTrace } },
                    entityName = "rel_Category_Collection"
                };
            }
        }
    }
}
