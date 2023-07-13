using Dapper;
using Microsoft.Extensions.Options;
using Store.Models.DataConfigue;
using Store.Models.ViewModel;

namespace Store.Services.Store
{
    public class StoreServices : BaseRepository, IStore
    {
        public StoreServices(IOptions<configue> connectionstring, IConfiguration config) : base(connectionstring, config)
        {
        }

        public async Task<IEnumerable<StoreModel>> StoreModelDetail()
        {
            return await QueryAsync<StoreModel>("data", null, commandType: System.Data.CommandType.StoredProcedure);

        }

        public async Task<IEnumerable<WarehouseModel>> WarehouseDetail()
        {
            return await QueryAsync<WarehouseModel>("dataw", null, commandType: System.Data.CommandType.StoredProcedure);

        }

        public async Task<IEnumerable<item>> itemDetail()
        {
            return await QueryAsync<item>("datai", null, commandType: System.Data.CommandType.StoredProcedure);

        }







    }
}
