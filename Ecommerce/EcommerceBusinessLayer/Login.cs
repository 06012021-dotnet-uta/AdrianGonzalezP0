using EcommerceDbContext;
using Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreAccount = StoreModels.Account;

namespace EcommerceBusinessLayer
{
    public class Login
    {
        private readonly Project0Context _;
        public Login ()
        {
            _ = new();
        }

        public StoreAccount LoginUser(string username, string password) 
        {

            try
            {
                Account account = _.Accounts
                    .SingleOrDefault(account => account.Username == username.ToLower().Trim() && account.Password == password.ToLower().Trim());

                return MapperClassDBToApp.DbAccountToClassAccount(account);
            }
            catch (Exception)
            {
                Console.WriteLine($"Incorrect username or password");
                return null;
            }
        } 
    }
}
