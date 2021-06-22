using EcommerceDbContext;
using Mapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreAccount = StoreModels.Account;
using StoreCustomer = StoreModels.Customer;

namespace EcommerceBusinessLayer
{
    public class Signup
    {
        private readonly Project0Context _;
        public Signup ()
        {
            _ = new();
        }

        /// <summary>
        /// Create a new account
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public bool CreateAccount(StoreAccount account)
        {
            Account newAccount = MapperClassAppToDb.AppAccountToDbAccount(account);
            try
            {
                 _.Accounts.Add(newAccount);
                 _.SaveChanges();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                Console.WriteLine($"Error - Could not create Account:\n{account.accountInfo()}");
                return false;
            }
        }

        /// <summary>
        /// Create a new Customer 
        /// </summary>
        /// <param name="newCustomer"></param>
        /// <returns></returns>
        public bool CreateCustomer(StoreCustomer newCustomer)
        {
            Customer customer = MapperClassAppToDb.AppCustomerToDbCustomer(newCustomer);
            try
            {
                 _.Customers.AddAsync(customer);
                 _.SaveChanges();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                Console.WriteLine($"Error - Could not create customer:\n{newCustomer.customerInfo()}");
                return false;
            }
        }
    }
}
