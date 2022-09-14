using Core.DTO.rel_Category_Collection;
using Core.Interfaces.rel_Category_Collection;
using Dapper;
using Infrastructure.Data;
using System.Data;

namespace Infrastructure.Repositories.rel_Category_Collection
{
    public class Cat_CollectionRepository : ICat_CollectionRepository
    {
        private readonly DapperContext context;

        public Cat_CollectionRepository(DapperContext context)
        {
            this.context = context;
        }

        public async Task insertRel(int idCollection, int idCategory)
        {
            var query = "sp_rel_Category_Collection_Insert";

            var parameters = new DynamicParameters();
            parameters.Add("@idCollection", idCollection, DbType.Int32);
            parameters.Add("@idCategory", idCategory, DbType.Int32);

            using var connection = context.SQLConnection();
            await connection.QueryAsync(query, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
