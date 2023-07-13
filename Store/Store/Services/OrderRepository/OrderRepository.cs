using Dapper;
using Microsoft.Extensions.Options;
using Store.Models.DataConfigue;
using Store.Models.ViewModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Store.Services.OrderRepository
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public OrderRepository(IOptions<configue> connectionstring, IConfiguration config) : base(connectionstring, config)
        {
        }

        public async Task<int> SaveOrder(List<SaveOrderModel> save)
        {
            int data = 0;
            foreach (var item in save)
            {
                var param = new DynamicParameters();
                param.Add("@Storeid", item.storeid);
                param.Add("@warhousid", item.Warehouseid);
                param.Add("@itemid", item.Itemid);
                param.Add("@quantity", item.Quantity);
                 data= await ExecuteAsync<SaveOrderModel>("orderInfo", param, commandType: System.Data.CommandType.StoredProcedure);
            }
            return data;
        }
    }
}
