

using StoreModels;
using System.Collections.Generic;

namespace EcommerceBusinessLayer
{
    public interface IAccount: ICrud<Account>
    {
        List<Account> GetAllAccounts();
        Account GetAccount(string username);
        bool Credentials(Account account);
    }
}