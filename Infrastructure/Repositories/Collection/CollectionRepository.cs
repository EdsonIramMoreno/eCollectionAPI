using Core.DTO.Collection;
using Core.Entities.CollectionInfo;
using Core.Interfaces.Collection;
using Core.Utilities;
using Dapper;
using Infrastructure.Data;
using System.Data;

namespace Infrastructure.Repositories.Collection
{
    public class CollectionRepository : ICollectionRepository
    {
        private readonly DapperContext context;

        public CollectionRepository(DapperContext context)
        {
            this.context = context;
        }

        public async Task CollectionInfoUpdate(CollectionInfoUpdateDTO collection)
        {
            var query = "sp_collectionInfo_Update";

            var path = "Collections/Collection_" + collection.collectionId + "/" + collection.collectionId;
            string imageUrl = await ImageUtility.uploadImage(context.FireBaseKey(), context.FireBaseBucket(), context.FireBaseUser(), context.FireBasePassword(), path, collection.collectionCover);


            var parameters = new DynamicParameters();
            parameters.Add("@collectionId", collection.collectionId, DbType.String);
            parameters.Add("@collectionName", collection.collectionName, DbType.String);
            parameters.Add("@collectionCover", imageUrl, DbType.String);

            using var connection = context.SQLConnection();
            await connection.QueryAsync(query, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task CreateCollection(CollectionInfoInsertDTO collectionInfo)
        {
            var query = "sp_collectionInfo_Insert";

            var parameters = new DynamicParameters();
            parameters.Add("@collectionName", collectionInfo.collectionName, DbType.String);
            parameters.Add("@collectionCover", "", DbType.String);
            parameters.Add("@fk_userId", collectionInfo.fk_userId, DbType.String);

            using var connection = context.SQLConnection();
            var collectionId = await connection.QueryFirstOrDefaultAsync<int>(query, parameters, commandType: CommandType.StoredProcedure);

            await this.CollectionInfoUpdate(new CollectionInfoUpdateDTO { 
                    collectionId = collectionId,
                    collectionCover = collectionInfo.collectionCover,
                    collectionName = collectionInfo.collectionName}
            );
        }

        public async Task DeleteCollection(int collectionId)
        {
            var query = "sp_CollectionInfo_Delete";

            var parameters = new DynamicParameters();
            parameters.Add("@collectionId", collectionId, DbType.String);

            using var connection = context.SQLConnection();
            await connection.QueryAsync(query, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<CollectionInfoMod> getCollectionById(int collectionId)
        {
            var query = "sp_collectionInfo_get";

            using var connection = context.SQLConnection();
            CollectionInfoMod collection = await connection.QueryFirstOrDefaultAsync<CollectionInfoMod>(query, new { collectionId }, commandType: CommandType.StoredProcedure);

            return collection;
        }

        public async Task<List<CollectionInfoDisplayMod>> getCollectionInfoDisplay(string fk_userId)
        {
            var query = "sp_collectionInfo_Display_get";

            var parameters = new DynamicParameters();
            parameters.Add("@userId", fk_userId, DbType.String);

            using var connection = context.SQLConnection();
            List<CollectionInfoDisplayMod> collections = (await connection.QueryAsync<CollectionInfoDisplayMod>(query, parameters, commandType: CommandType.StoredProcedure)).ToList();

            return collections;
        }
    }
}
