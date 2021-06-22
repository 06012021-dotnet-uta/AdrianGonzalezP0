using StoreModels;
using System.Collections.Generic;

namespace EcommerceBusinessLayer
{
    interface ICustomer: ICrud<Customer>
    {
        List<Customer> SearchCustomer(string Fname, string Lname);
        Customer SearchCustomer(string username);
        long LengthOfCustomers();
    }
}
