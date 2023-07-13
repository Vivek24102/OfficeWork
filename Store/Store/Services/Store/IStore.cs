using Store.Models.ViewModel;

namespace Store.Services.Store
{
    public interface IStore
    {
        Task<IEnumerable<StoreModel>> StoreModelDetail();
        Task<IEnumerable<WarehouseModel>> WarehouseDetail();

        Task<IEnumerable<item>> itemDetail();
    }
}
