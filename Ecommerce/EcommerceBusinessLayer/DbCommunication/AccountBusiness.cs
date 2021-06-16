using System;
using System.Linq;
using EcommerceDbContext;
using Mapper;
using DbContext;
using Microsoft.EntityFrameworkCore;
using StoreAccount = StoreModels.Account;
using DbAccount = EcommerceDbContext.Account;


namespace EcommerceBusinessLayer
{
    public class AccountBusiness : IAccountBusiness
    {

        private Project0Context _context;

        public AccountBusiness()
        {
            _context = DbConextProject.DbContext;
        }


        /// <summary>
        /// Is responsible for creating the account 
        /// </summary>
        /// <param name="accountObj"></param>
        /// <returns>If Successful returns true if not false</returns>
        public bool addAccount(StoreAccount accountObj)
        {
            DbAccount newAccount = MapperClassAppToDb.AppAccountToDbAccount(accountObj);

            try
            {
                _context.Accounts.Add(newAccount);
                _context.SaveChanges();
                return true;
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine($"\nError username already exists: {accountObj.Username}\nError Message: {e.Message}\n");
                return false;
            }
        }


        /// <summary>
        /// Deletes account from database
        /// </summary>
        /// <param name="accountObj"></param>
        /// <returns>If Successful returns true if not false</returns>
        public bool deleteAccount(string Username)
        {

            try
            {
                var account = _context.Accounts.Single(acc => acc.Username == Username);
                _context.Accounts.Remove(account);
                _context.SaveChanges();
                return true;
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine($"Error could not remove account: {e.Message}");
                return false;
            }
        }

        /// <summary>
        /// Update Account from Database
        /// </summary>
        /// <param name="accountObj"></param>
        /// <returns>Returns true if update succeeded</returns>
        public bool updateAccount(StoreAccount accountObj)
        {
            DbAccount newAccount = MapperClassAppToDb.AppAccountToDbAccount(accountObj);
            try
            {
                _context.Accounts.Update(newAccount);
                _context.SaveChanges();
                return true;
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine($"Error could not add update account: {e.Message}");
                return false;
            }
        }

        /// <summary>
        /// Retrieves and displays all of information about the users
        /// </summary>
        /// 
        public void displayAllAccounts()
        {
            try 
            {
                var accounts = _context.Accounts.Select(acc => acc);

                foreach (DbAccount account in accounts)
                {
                    Console.WriteLine($"Username: {account.Username} Password: {account.Password}\n");
                }
            } 
            catch (ArgumentNullException e) {
                throw new Exception($"Error could not retrive accounts: {e.Message}");
            }
        }

        public StoreAccount createAccount()
        {
            StoreAccount newAccount = new();

            // Ask for all fields required
            Console.Write("Username: ");
            newAccount.Username = Console.ReadLine().Trim();
            Console.Write("Password: ");
            newAccount.Password = Console.ReadLine();

            return newAccount;
        }

        /// <summary>
        /// Checks if user exists in the database with the given username and password
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>Returns true if user exists in the database</returns>
        public bool credentials(String userName, String password)
        {
            try
            {
                var account = _context.Accounts.Single(acc => acc.Username == userName && acc.Password == password);
                return true;
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine($"\nError: Incorrect username or password");
                return false;
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine($"\nError: Incorrect username or password");
                return false;
            }
        }
    }
}