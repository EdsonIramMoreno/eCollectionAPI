using Core.DTO;
using Core.DTO.Collection;

namespace Core.Interfaces.Collection
{
    public interface ICollectionServices
    {
        public Task<ResponseDTO> CreateCollection(CollectionInfoInsertDTO collectionInfo);
    }
}
