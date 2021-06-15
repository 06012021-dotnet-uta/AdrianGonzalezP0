using System;
using System.Linq;
using EcommerceDbContext;
using Mapper;

namespace EcommerceBusinessLayer
{
    public class AccountBusiness : IAccountBusiness
    {

        private Project0Context _context;

        public AccountBusiness()
        {
            _context = new Project0Context();
        }


        /// <summary>
        /// Is responsible for creating the account 
        /// </summary>
        /// <param name="accountObj"></param>
        /// <returns>If Successful returns true if not false</returns>
        public bool createAccount(StoreModels.Account accountObj)
        {
            EcommerceDbContext.Account newAccount = MapperClassAppToDb.AppAccountToDbAccount(accountObj);

            try
            {
                _context.Accounts.Add(newAccount);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error could not add account: {e.Message}");
                return false;
            }
        }


        /// <summary>
        /// Deletes account from database
        /// </summary>
        /// <param name="accountObj"></param>
        /// <returns>If Successful returns true if not false</returns>
        public bool deleteAccount(StoreModels.Account accountObj)
        {
            EcommerceDbContext.Account newAccount = MapperClassAppToDb.AppAccountToDbAccount(accountObj);

            try
            {
                _context.Accounts.Remove(newAccount);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error could not remove account: {e.Message}");
                return false;
            }
        }

        /// <summary>
        /// Update Account from Database
        /// </summary>
        /// <param name="accountObj"></param>
        /// <returns></returns>
        public bool updateAccount(StoreModels.Account accountObj)
        {
            EcommerceDbContext.Account newAccount = MapperClassAppToDb.AppAccountToDbAccount(accountObj);

            try
            {
                _context.Accounts.Update(newAccount);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error could not add update account: {e.Message}");
                return false;
            }
        }

        /// <summary>
        /// Retrieves and displays all of information about the users
        /// </summary>
        public void displayAllAccounts()
        {
            var accounts = _context.Accounts.Select(acc => acc);

            foreach (EcommerceDbContext.Account account in accounts)
            {
                Console.WriteLine($"Username: {account.Username} Password: {account.Password}\n");
            }
        }
    }
}