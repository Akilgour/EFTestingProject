using System;

namespace EFModels.Model
{
    public class SaleOrderItem
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Quantity { get; set; }

        public double CostPerItem { get; set; }

        public Guid SaleOrderId { get; set; }
    }
}