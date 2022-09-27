
using Core.DTO.Category;
using Core.DTO.Collection;
using Core.Entities.CategoryList;
using Core.Entities.CollectionInfo;

namespace Core.Mappers
{
    public class CollectionMapper
    {
        public static CollectionInfoDisplayDTO mapDisplayMODtoDTO(CollectionInfoDisplayMod collection)
        {
            return new CollectionInfoDisplayDTO
            {
                collectionId = collection.collectionId,
                collectionName = collection.collectionName,
                collectionCover = collection.collectionCover,
                itemNumberCollection = collection.itemNumberCollection,
                categories = collection.categories,
                fk_userId = collection.fk_userId,
                lastUpdateDate = collection.lastUpdateDate.ToShortDateString(),
                creationDate = collection.creationDate.ToShortDateString()
            };
        }
        public static CollectionInfoDTO mapMODtoDTO(CollectionInfoMod collection)
        {
            return new CollectionInfoDTO
            {
                collectionId = collection.collectionId,
                collectionName = collection.collectionName,
                collectionCover = collection.collectionCover,
                totalPrice = collection.totalPrice,
                fk_userId = collection.fk_userId,
                lastUpdateDate = collection.lastUpdateDate.ToShortDateString(),
                creationDate = collection.creationDate.ToShortDateString()
            };
        }
    }
}
