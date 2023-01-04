using Core.DTO.Collection;
using Core.Entities.CollectionInfo;

namespace Core.Interfaces.Collection
{
    public interface ICollectionRepository
    {
        public Task<int> CreateCollection(CollectionInfoInsertDTO collectionInfo);
        public Task<List<CollectionInfoDisplayMod>> getCollectionInfoDisplay(string fk_userId);
        public Task<CollectionInfoMod> getCollectionById(int collectionId);
        public Task CollectionInfoUpdate(CollectionInfoUpdateDTO collection);
        public Task DeleteCollection(int collectionId);
    }
}
