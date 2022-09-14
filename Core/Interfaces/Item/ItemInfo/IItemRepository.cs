using Core.DTO.Item.ItemInfo;

namespace Core.Interfaces.Item.ItemInfo
{
    public interface IItemRepository
    {
        public Task CreateItem(itemInsertInfoDTO itemInfo);
        public Task Update(itemUpdateInfoDTO itemInfo);
        public Task<List<itemDisplayInfoDTO>> getAllItemsByCollectionId(int collectionId);
        public Task<List<itemCompleteInfoDTO>> getItemById(int collectionId, int itemId);
    }
}
