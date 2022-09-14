using Core.DTO.Item.ItemInfo;
using Core.DTO.Item.ItemPhoto;
using Core.Entities.CategoryList;
using Core.Entities.Item.ItemPhoto;
using Core.Interfaces.Item.ItemPhoto;
using Dapper;
using Infrastructure.Data;
using System.Data;

namespace Infrastructure.Repositories.Item
{
    public class ItemPhotoRepository : IItemPhotoRepository
    {
        private readonly DapperContext context;

        public ItemPhotoRepository(DapperContext context)
        {
            this.context = context;
        }

        public async Task DeletePhoto(int itemPhotoId)
        {
            var query = "sp_itemPhoto_Delete";

            var parameters = new DynamicParameters();
            parameters.Add("@itemPhotoId", itemPhotoId, DbType.String);

            using var connection = context.SQLConnection();
            await connection.QueryAsync(query, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<ItemPhotoMod>> getAllItemPhotos(int itemId)
        {
            var query = "sp_itemPhoto_get";

            var parameters = new DynamicParameters();
            parameters.Add("@itemId", itemId, DbType.Int32);

            using var connection = context.SQLConnection();
            List<ItemPhotoMod> category = (await connection.QueryAsync<ItemPhotoMod>(query, parameters, commandType: CommandType.StoredProcedure)).ToList();

            return category;
        }

        public async Task<ItemPhotoMod> getItemPhotosById(int itemId, int photoId)
        {
            var query = "sp_itemPhoto_get";

            var parameters = new DynamicParameters();
            parameters.Add("@itemId", itemId, DbType.Int32);
            parameters.Add("@itemPhotoId", photoId, DbType.Int32);

            using var connection = context.SQLConnection();
            ItemPhotoMod photos = await connection.QueryFirstOrDefaultAsync<ItemPhotoMod>(query, parameters, commandType: CommandType.StoredProcedure);

            return photos;
        }

        public async Task InsertPhoto(ItemPhotoInsertDTO itemPhoto)
        {
            var query = "sp_itemPhoto_Insert";

            var parameters = new DynamicParameters();
            parameters.Add("@itemPhoto", itemPhoto.itemPhoto, DbType.String);
            parameters.Add("@itemId", itemPhoto.fk_itemId, DbType.Int32);

            using var connection = context.SQLConnection();
            await connection.QueryAsync(query, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
