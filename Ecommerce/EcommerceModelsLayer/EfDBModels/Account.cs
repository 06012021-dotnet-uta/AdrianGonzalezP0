using System;
using System.Collections.Generic;

#nullable disable

namespace EcommerceDbContext
{
    public partial class Account
    {
        public Account()
        {
            Customers = new HashSet<Customer>();
        }

        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
