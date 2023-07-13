namespace Store.Models.ViewModel
{
    public class Details
    {
        public IEnumerable<StoreModel> store { get; set; }


        public IEnumerable<WarehouseModel> warehouses { get; set; }


        public IEnumerable<item> items { get; set; }
    }
}
