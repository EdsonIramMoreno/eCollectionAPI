using Core.DTO.Item.ItemInfo;
using Core.Entities.CategoryList;
using Core.Entities.Item.ItemPhoto;
using Core.Interfaces.Item.ItemInfo;
using Core.Utilities;
using Dapper;
using Infrastructure.Data;
using System.Data;

namespace Infrastructure.Repositories.Item
{
    public  class ItemRepository : IItemRepository
    {
        private readonly DapperContext context;

        public ItemRepository(DapperContext context)
        {
            this.context = context;
        }

        public async Task CreateItem(itemInsertInfoDTO itemInfo)
        {
            var query = "sp_itemInfo_Insert";

            var parameters = new DynamicParameters();
            parameters.Add("@itemName", itemInfo.itemName, DbType.String);
            parameters.Add("@itemDescription", itemInfo.itemDescription, DbType.String);
            parameters.Add("@itemCover", "", DbType.String);
            parameters.Add("@fk_collectionId", itemInfo.fk_collectionId, DbType.Int32);
            parameters.Add("@acquiredPrice", itemInfo.acquiredPrice, DbType.Decimal);
            parameters.Add("@marketPrice", itemInfo.marketPrice, DbType.Decimal);

            using var connection = context.SQLConnection();
            var itemId = await connection.QueryFirstOrDefaultAsync<int>(query, parameters, commandType: CommandType.StoredProcedure);

            await this.Update(new itemUpdateInfoDTO
            {
                itemId = itemId,
                itemCover = itemInfo.itemCover,
                itemDescription = itemInfo.itemDescription,
                itemName = itemInfo.itemName,
                marketPrice = itemInfo.marketPrice,
                acquiredPrice = itemInfo.acquiredPrice
            });
        }

        public async Task<itemCompleteInfoDTO> getItemById(int collectionId, int itemId)
        {
            var query = "sp_itemInfo_get";

            var parameters = new DynamicParameters();
            parameters.Add("@collectionId", collectionId, DbType.Int32);
            parameters.Add("@itemId", itemId, DbType.Int32);

            using var connection = context.SQLConnection();
            var itemComplete = (await connection.QuerySingleOrDefaultAsync<itemCompleteInfoDTO>(query, parameters, commandType: CommandType.StoredProcedure));

            return itemComplete;
        }

        public async Task<List<itemDisplayInfoDTO>> getAllItemsByCollectionId(int collectionId)
        {
            var query = "sp_itemInfo_get";

            var parameters = new DynamicParameters();
            parameters.Add("@collectionId", collectionId, DbType.Int32);

            using var connection = context.SQLConnection();
            List<itemDisplayInfoDTO> itemDisplay = (await connection.QueryAsync<itemDisplayInfoDTO>(query, parameters, commandType: CommandType.StoredProcedure)).ToList();

            return itemDisplay;
        }

        public async Task Update(itemUpdateInfoDTO itemInfo)
        {
            var query = "sp_itemInfo_Update";

            var collectionId = await getCollectionId(itemInfo.itemId);

            var img = itemInfo.itemCover.OpenReadStream();
            var path = "Collections/Collection_" + collectionId + "/Items_" + itemInfo.itemId + "/" + itemInfo.itemId;
            string imageUrl = await ImageUtility.uploadImage(context.FireBaseKey(), context.FireBaseBucket(), context.FireBaseUser(), context.FireBasePassword(), path, img);


            var parameters = new DynamicParameters();
            parameters.Add("@itemId", itemInfo.itemId, DbType.Int32);
            parameters.Add("@itemName", itemInfo.itemName, DbType.String);
            parameters.Add("@itemDescription", itemInfo.itemDescription, DbType.String);
            parameters.Add("@marketPrice", itemInfo.marketPrice, DbType.Decimal);
            parameters.Add("@acquiredPrice", itemInfo.acquiredPrice, DbType.Decimal);
            parameters.Add("@itemCover", imageUrl, DbType.String);

            using var connection = context.SQLConnection();
            await connection.QueryAsync(query, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteItem(int itemId)
        {
            var query = "sp_itemInfo_Delete";

            var parameters = new DynamicParameters();
            parameters.Add("@itemId", itemId, DbType.String);

            using var connection = context.SQLConnection();
            await connection.QueryAsync(query, parameters, commandType: CommandType.StoredProcedure);
        }

        private async Task<int> getCollectionId(int itemId)
        {
            var query = "sp_itemInfo_CollectionId_get";

            var parameters = new DynamicParameters();
            parameters.Add("@itemId", itemId, DbType.String);

            using var connection = context.SQLConnection();
            return await connection.QueryFirstOrDefaultAsync<int>(query, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
