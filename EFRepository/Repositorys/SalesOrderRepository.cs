using EFModels.Model;
using EFRepository.Context;
using System;
using System.Linq;

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
    }
}