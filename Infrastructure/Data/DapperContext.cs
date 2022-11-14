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
        private readonly string _fireBaseBucket;
        private readonly string _fireBaseUser;
        private readonly string _fireBasePassword;

        public DapperContext(IConfiguration configuration)
        {
            this.configuration = configuration;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _fireBaseConnectionString = configuration.GetConnectionString("FireBaseKey");
            _fireBaseBucket = configuration["BucketStorage:FireBaseBucket"];
            _fireBaseUser = configuration["UsersCredentials:email"];
            _fireBasePassword = configuration["UsersCredentials:password"];
        }

        public IDbConnection SQLConnection() => new SqlConnection(_connectionString);  
        public string FireBaseKey() => _fireBaseConnectionString;  
        public string FireBaseBucket() => _fireBaseBucket;
        public string FireBaseUser() => _fireBaseUser;
        public string FireBasePassword() => _fireBasePassword;
    }
}
