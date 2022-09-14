using Core.DTO;
using Core.DTO.Category;
using Core.DTO.Item.ItemInfo;
using Core.Interfaces.Item.ItemInfo;
using Core.Mappers;
using Infrastructure.Repositories.Category;
using Infrastructure.Repositories.Item;

namespace API.Application
{
    public class ItemServices : IItemServices
    {
        private readonly IItemRepository itemRepository;

        public ItemServices(IItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }

        public async Task<ResponseDTO> CreateItem(itemInsertInfoDTO itemInfo)
        {
            try
            {
                // 1.0 Obtener información del Usuario
                await itemRepository.CreateItem(itemInfo);

                // 2.0 Retornar Listado
                return new ResponseDTO
                {
                    status = 200,
                    response = "The item has been created succesfully",
                    errors = null,
                    entityName = "ItemInfo"
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO
                {
                    status = 500,
                    response = "One or more mistakes where found in the consult",
                    errors = new List<ErrorDTO> { new ErrorDTO { message = ex.Message, stackTrace = ex.StackTrace } },
                    entityName = "ItemInfo"
                };
            }
        }

        public async Task<returnItemCompleteInfoDTO> getItemById(int collectionId, int itemId)
        {
            try
            {
                // 1 Get CategoryModList
                var itemDisplay = await itemRepository.getItemById(collectionId, itemId);

                // 2 Retornar Listado
                if (itemDisplay.Count <= 0)
                    return new returnItemCompleteInfoDTO
                    {
                        status = 404,
                        response = "CategoryList was NOT found.",
                        errors = null,
                        itemInfo = null
                    };

                return new returnItemCompleteInfoDTO
                {
                    status = 200,
                    response = "CategoryList was found.",
                    errors = null,
                    itemInfo = itemDisplay
                };
            }
            catch (Exception ex)
            {
                return new returnItemCompleteInfoDTO
                {
                    status = 500,
                    response = "One or more mistakes where found in the consult",
                    errors = new List<ErrorDTO> { new ErrorDTO { message = ex.Message, stackTrace = ex.StackTrace } },
                    itemInfo = null
                };
            }
        }

        public async Task<returnItemInfoDisplayDTO> getAllItemsByCollectionId(int collectionId)
        {
            try
            {
                // 1 Get CategoryModList
                var itemDisplay = await itemRepository.getAllItemsByCollectionId(collectionId);

                // 2 Retornar Listado

                if (itemDisplay.Count <= 0)
                    return new returnItemInfoDisplayDTO
                    {
                        status = 404,
                        response = "CategoryList was NOT found.",
                        errors = null,
                        items = null
                    };

                return new returnItemInfoDisplayDTO
                {
                    status = 200,
                    response = "CategoryList was found.",
                    errors = null,
                    items = itemDisplay
                };
            }
            catch (Exception ex)
            {
                return new returnItemInfoDisplayDTO
                {
                    status = 500,
                    response = "One or more mistakes where found in the consult",
                    errors = new List<ErrorDTO> { new ErrorDTO { message = ex.Message, stackTrace = ex.StackTrace } },
                    items = null
                };
            }
        }

        public async Task<ResponseDTO> UpdateItem(itemUpdateInfoDTO itemInfo)
        {
            try
            {
                // 1.0 Obtener información del Usuario
                await itemRepository.Update(itemInfo);

                // 2.0 Retornar Listado
                return new ResponseDTO
                {
                    status = 200,
                    response = "The item has been updated succesfully",
                    errors = null,
                    entityName = "ItemInfo"
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO
                {
                    status = 500,
                    response = "One or more mistakes where found in the consult",
                    errors = new List<ErrorDTO> { new ErrorDTO { message = ex.Message, stackTrace = ex.StackTrace } },
                    entityName = "ItemInfo"
                };
            }
        }
    }
}
