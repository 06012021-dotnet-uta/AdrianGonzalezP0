using System;
using System.Collections.Generic;

#nullable disable

namespace EcommerceDbContext
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public string Username { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }

        public virtual Account UsernameNavigation { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
