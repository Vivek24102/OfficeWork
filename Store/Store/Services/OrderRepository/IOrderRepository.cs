using Store.Models.ViewModel;

namespace Store.Services.OrderRepository
{
    public interface IOrderRepository
    {
        Task<int> SaveOrder(List<SaveOrderModel> save);
    }
}
