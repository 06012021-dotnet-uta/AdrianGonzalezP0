using EcommerceDbContext;
using Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreAccount = StoreModels.Account;
using StoreCustomer = StoreModels.Customer;

namespace EcommerceBusinessLayer
{
    public class Login
    {
        private readonly Project0Context _;
        public Login ()
        {
            _ = new();
        }

        /// <summary>
        /// Returns an exisiting account
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>An exisitng account </returns>
        public bool LoginUser(StoreAccount account) 
        {

            try
            {
                Account acc = MapperClassAppToDb.AppAccountToDbAccount(account);
                return _.Accounts.Contains(acc); 
            }
            catch (Exception)
            {
                Console.WriteLine($"Incorrect username or password");
                return false;
            }
        }
        
        public StoreCustomer GetUserInfo(StoreAccount acc)
        {
            try
            {
                Customer customer = _.Customers.SingleOrDefault(c => c.Username == acc.Username);
                
                return  MapperClassDBToApp.DbCustomerToClassCustomer(customer);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Error - Could not retrieve Customer");
                return null;
            }
        }
    }
}
