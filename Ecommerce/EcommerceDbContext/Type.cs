using System;
using System.Collections.Generic;

#nullable disable

namespace EcommerceDbContext
{
    public partial class Type
    {
        public Type()
        {
            Products = new HashSet<Product>();
        }

        public int TypeId { get; set; }
        public string Type1 { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
