using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Store.Models.DataConfigue;
using System.Data;

namespace Store.Services
{
    public class BaseRepository
    {
        private configue _connectionstring { get; set; }

        private readonly IConfiguration _configuration;
        public BaseRepository(IOptions<configue> connectionstring, IConfiguration config)
        {
            _connectionstring = connectionstring.Value;
            _configuration = config;

        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(String sql, object param = null, IDbTransaction transaction = null,
            int? commandTimeout = null, CommandType? commandType = null)
        {
            string conString = ConfigurationExtensions.GetConnectionString(_configuration, "DefaultConnection");
            using (SqlConnection con = new SqlConnection(conString))
            {
                await con.OpenAsync();

                return await con.QueryFirstOrDefaultAsync<T>(sql, param, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CommandType? commandType = null)
        {
            string conString = ConfigurationExtensions.GetConnectionString(_configuration, "DefaultConnection");

            using (SqlConnection con = new SqlConnection(conString))
            {
                await con.OpenAsync();
                return await con.QueryAsync<T>(sql, param, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> ExecuteAsync<T>(string sql, object param = null, IDbTransaction transaction = null,
            CommandType? commandType = null)
        {
            string conString = ConfigurationExtensions.GetConnectionString(_configuration, "DefaultConnection");
            using (SqlConnection con = new SqlConnection(conString))
            {
                await con.OpenAsync();
                return await con.ExecuteAsync(sql, param, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
