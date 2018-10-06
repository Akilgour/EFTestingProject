using EFModels.Model;
using System.Data.Entity;

namespace EFRepository.Context
{
    public class MyContext : DbContext
    {
        public MyContext()
        {
        }

        public IDbSet<SaleOrder> SaleOrder { get; set; }
        public IDbSet<SaleOrderItem> SaleOrderItem { get; set; }
    }
}