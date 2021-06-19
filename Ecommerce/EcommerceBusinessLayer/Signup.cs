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

        public async Task<bool> CreateAccount(StoreAccount account)
        {
            Account newAccount = MapperClassAppToDb.AppAccountToDbAccount(account);
            try
            {
                await _.Accounts.AddAsync(newAccount);
                await _.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                Console.WriteLine($"Error - Could not create Account:\n{account.accountInfo()}");
                return false;
            }
        }

        public async Task<bool> CreateCustomer(StoreCustomer newCustomer)
        {
            Customer customer = MapperClassAppToDb.AppCustomerToDbCustomer(newCustomer);
            try
            {
                await _.Customers.AddAsync(customer);
                await _.SaveChangesAsync();
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
