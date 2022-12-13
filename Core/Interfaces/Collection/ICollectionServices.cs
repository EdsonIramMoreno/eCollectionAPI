using Core.DTO;
using Core.DTO.Collection;
using Core.Entities.CollectionInfo;

namespace Core.Interfaces.Collection
{
    public interface ICollectionServices
    {
        public Task<int> CreateCollection(CollectionInfoInsertDTO collectionInfo);
        public Task<List<CollectionInfoDisplayDTO>> getCollectionInfoDisplay(string fk_userId);
        public Task<CollectionInfoDTO> getCollectionById(int collectionId);
        public Task<ResponseDTO> CollectionInfoUpdate(CollectionInfoUpdateDTO collection);
        public Task<ResponseDTO> DeleteCollection(int collectionId);
    }
}
