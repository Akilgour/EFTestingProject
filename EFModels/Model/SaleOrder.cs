using System;
using System.Collections.Generic;

namespace EFModels.Model
{
    public class SaleOrder
    {
        public Guid Id { get; set; }

        public string CustomerFirstName { get; set; }

        public string CustomerSecondName { get; set; }

        public string Address { get; set; }

        public virtual List<SaleOrderItem> SaleOrderItems { get; set; }
    }
}