using Core.DTO.Collection;
using Core.Interfaces.Collection;
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

        public async Task CreateCollection(CollectionInfoInsertDTO collectionInfo)
        {
            var query = "sp_collectionInfo_Insert";

            var parameters = new DynamicParameters();
            parameters.Add("@collectionName", collectionInfo.collectionName, DbType.String);
            parameters.Add("@collectionCover", collectionInfo.collectionCover, DbType.String);
            parameters.Add("@fk_userId", collectionInfo.fk_userId, DbType.String);

            using var connection = context.SQLConnection();
            await connection.QueryAsync(query, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
