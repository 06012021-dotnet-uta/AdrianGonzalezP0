using StoreModels;
using System.Collections.Generic;
using DbCustomer = EcommerceDbContext.Customer;

namespace EcommerceBusinessLayer
{
    interface ICustomerBusiness
    {
        bool addCustomer(Customer accountObj);
        bool deleteCustomer(int custmerId);
        bool updateCustomer(int customerId);
        List<DbCustomer> searchCustomer(string Fname, string Lname);
        DbCustomer searchCustomer(string username);
    }
}
