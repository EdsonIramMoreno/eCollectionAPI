using Core.DTO;
using Core.DTO.Item.ItemInfo;

namespace Core.Interfaces.Item.ItemInfo
{
    public interface IItemServices
    {
        public Task<ResponseDTO> CreateItem(itemInsertInfoDTO itemInfo);
        public Task<ResponseDTO> UpdateItem(itemUpdateInfoDTO itemInfo);
        public Task<List<itemDisplayInfoDTO>> getAllItemsByCollectionId(int collectionId);
        public Task<itemCompleteInfoDTO> getItemById(int collectionId,int itemId);
    }
}
