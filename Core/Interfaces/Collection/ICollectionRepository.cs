using Core.DTO.Collection;
using Core.DTO.User;

namespace Core.Interfaces.Collection
{
    public interface ICollectionRepository
    {
        public Task CreateCollection(CollectionInfoInsertDTO collectionInfo);
    }
}
