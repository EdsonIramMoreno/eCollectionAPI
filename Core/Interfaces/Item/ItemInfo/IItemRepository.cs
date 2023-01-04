using Core.DTO.Item.ItemInfo;

namespace Core.Interfaces.Item.ItemInfo
{
    public interface IItemRepository
    {
        public Task<int> CreateItem(itemInsertInfoDTO itemInfo);
        public Task Update(itemUpdateInfoDTO itemInfo);
        public Task<List<itemDisplayInfoDTO>> getAllItemsByCollectionId(int collectionId);
        public Task<itemCompleteInfoDTO> getItemById(int itemId);
        public Task DeleteItem(int itemId);
    }
}
