using Microsoft.AspNetCore.Mvc;
using Store.Models.ViewModel;
using Store.Services.OrderRepository;
using Store.Services.Store;

namespace Store.Controllers
{
    public class StoreController : Controller
     {

        private readonly IStore _store;
        private readonly IOrderRepository _order;

        public StoreController(IStore store,IOrderRepository order)
        {
            this._store = store;
            this._order = order;
        }
        public async Task<IActionResult> Store()
        {
            IEnumerable<WarehouseModel> data = await _store.WarehouseDetail();
            IEnumerable<item> data1 = await _store.itemDetail();
            IEnumerable<StoreModel> data2 = await _store.StoreModelDetail();
            Details obj = new Details()
            {
              items = data1,
              warehouses = data,
              store = data2

            };
          
            return View(obj);
        }
        [HttpPost]
        public async Task<IActionResult> Store(List<SaveOrderModel> data)
        {
          
            _order.SaveOrder(data);
            return RedirectToAction("Index", "Home");
         
        }



    }

}
