using Dapper;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDemo_Model.Config;

namespace WebDemo_Data
{
    public class BaseRepository
    {
        private DataConfig _connectionstring { get; set; }

        private readonly IConfiguration _configuration;
        public BaseRepository(IOptions<DataConfig> connectionstring,IConfiguration config)
        {


            _connectionstring = connectionstring.Value;
            _configuration = config;
        }
        public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
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
