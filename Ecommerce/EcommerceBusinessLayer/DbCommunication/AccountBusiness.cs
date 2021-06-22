using System;
using System.Linq;
using EcommerceDbContext;
using Mapper;
using DbContext;
using Microsoft.EntityFrameworkCore;
using StoreAccount = StoreModels.Account;
using DbAccount = EcommerceDbContext.Account;
using System.Collections.Generic;

namespace EcommerceBusinessLayer
{
    public class AccountBusiness : IAccount
    {

        private readonly Project0Context _context;
        private DbAccount dbAccount;
        private StoreAccount storeAccount;

        public AccountBusiness()
        {
            _context = DbConextProject.DbContext;
        }

        /// <summary>
        /// Creates an Account for new users
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Returns true if saved to database succesfully. False if an error occurred</returns>
        public bool Create(StoreAccount obj)
        {
            dbAccount = MapperClassAppToDb.AppAccountToDbAccount(obj);

            try
            {
                _context.Accounts.Add(dbAccount);
                _context.SaveChanges();
                return true;
            }
            catch (DbUpdateException e)
            
            {
                Console.WriteLine($"Could not create account with {obj.accountInfo()}\nError: {e.Message}");
                return false;
            }
        }

        /// <summary>
        /// Finds an user in the Database with username and passoword
        /// </summary>
        /// <param name="account">Instance of an Account</param>
        /// <returns>Returns true if user exists in the database. False if no user was found with username and password provided with</returns>
        public bool Credentials(StoreAccount account)
        {
            dbAccount = MapperClassAppToDb.AppAccountToDbAccount(account);

            try
            {
                return _context.Accounts.Contains(dbAccount);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine($"Could not retrieve account with {dbAccount.Username}\nError Message: {e.Message}");
                return false;
            }
        }

        /// <summary>
        /// Delete an existing account.
        /// </summary>
        /// <param name="obj">Instance of an Account</param>
        /// <returns></returns>
        public bool Delete(StoreAccount obj)
        {
            dbAccount = MapperClassAppToDb.AppAccountToDbAccount(obj);

            try
            {
                _context.Accounts.Remove(dbAccount);
                _context.SaveChanges();
                return true;
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine($"Could not delete account with {obj.Username}\nError: {e.Message}");
                return false;
            }
        }

        /// <summary>
        /// Finds a specific account
        /// </summary>
        /// <param name="username"></param>
        /// <returns>An existing account</returns>

        public StoreAccount GetAccount(string username)
        {
            try
            {
                dbAccount = _context.Accounts.Single(acc => acc.Username.ToLower().Trim() == username.ToLower().Trim());
                storeAccount = MapperClassDBToApp.DbAccountToClassAccount(dbAccount);
                return storeAccount;
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine($"Could Retrieve Account {username}\nError Message: {e.Message}");
                return null;
            }
        }

        /// <summary>
        /// Retrieves all of the accounts from database
        /// </summary>
        /// <returns>A List of Accounts</returns>
        public List<StoreAccount> GetAllAccounts()
        {
            List<StoreAccount> listOfAccounts = new();
            try
            {
                List<DbAccount> dbaccounts = _context.Accounts.ToList();

                listOfAccounts = dbaccounts.ConvertAll(dbAccount => MapperClassDBToApp.DbAccountToClassAccount(dbAccount));

                return listOfAccounts;

            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine($"Could not retrieve all account\nError Message:{e.Message}");
                return null;
            }
        }

        /// <summary>
        /// Retries an Account object by 
        /// </summary>
        /// <param name="obj">An instance of a Account Class</param>
        /// <returns>Returns an Account object or null if not found</returns>
        public StoreAccount Read(string Username)
        {
            try
            {
                dbAccount = _context.Accounts.Single(acc => acc.Username.ToLower().Trim() == Username.ToLower().Trim());
                storeAccount = MapperClassDBToApp.DbAccountToClassAccount(dbAccount);
                return storeAccount;
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine($"Could Retrieve Account {Username}\nError Message: {e.Message}");
                return null;
            }
        }

        /// <summary>
        /// Updates an existing account information
        /// </summary>
        /// <param name="obj">An instance of a Account Class</param>
        /// <returns>True if successfuly updated. False if failed to update</returns>
        public bool Update(StoreAccount obj)
        {
            try
            {

                dbAccount = MapperClassAppToDb.AppAccountToDbAccount(obj);
                _context.Accounts.Update(dbAccount);
                _context.SaveChanges();
                return true;
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine($"Could Retrieve Account {obj.Username}\nError Message: {e.Message}");
                return false;
            }
        }
    }
}