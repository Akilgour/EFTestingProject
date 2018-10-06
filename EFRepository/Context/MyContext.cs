using EFModels.Model;
using System.Data.Entity;

namespace EFRepository.Context
{
    public class MyContext : DbContext
    {
        public MyContext()
        {
        }

        public IDbSet<SaleOrder> SaleOrders { get; set; }
        public IDbSet<SaleOrderItem> SaleOrderItems { get; set; }
    }
}