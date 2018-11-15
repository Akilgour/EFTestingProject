using EFModels.Model;
using EFRepository.Context;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace EFRepository.Repositorys
{
    public class SalesOrderRepository
    {
        public readonly MyContext _context;

        public SalesOrderRepository(MyContext context)
        {
            _context = context;
        }

        public SaleOrder GetById(Guid id)
        {
            return _context.SaleOrders.First(x => x.Id == id);
        }

        public Task<SaleOrder> GetByIdAsync(Guid id)
        {
            return _context.SaleOrders.FirstAsync(x => x.Id == id);
        }
    }
}