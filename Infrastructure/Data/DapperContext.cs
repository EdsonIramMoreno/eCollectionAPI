using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Infrastructure.Data
{
    public class DapperContext
    {
        private readonly IConfiguration configuration;
        private readonly string _connectionString;
        private readonly string _fireBaseConnectionString;

        public DapperContext(IConfiguration configuration)
        {
            this.configuration = configuration;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _fireBaseConnectionString = configuration.GetConnectionString("FireBaseKey");
        }

        public IDbConnection SQLConnection() => new SqlConnection(_connectionString);  
        public string FireBaseKey() => _fireBaseConnectionString;  
    }
}
