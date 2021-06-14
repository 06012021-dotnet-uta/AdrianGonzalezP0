using System;
using System.Collections.Generic;

#nullable disable

namespace EcommerceDbContext
{
    public partial class Product
    {
        public Product()
        {
            Inventories = new HashSet<Inventory>();
            Orders = new HashSet<Order>();
        }

        public int ProductId { get; set; }
        public int? TypeId { get; set; }
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public string Description { get; set; }

        public virtual Type Type { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
