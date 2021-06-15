
//     place orders to store locations for customers
//     add a new customer
//     search customers by name
//     display details of an order
//     display all order history of a store location
//     display all order history of a customer
//     input validation
//     exception handling
//     persistent data (to a DB); no hardcoding of data.(prices, customers, order history, etc.)
//     (+5 pts): order history can be sorted by earliest, latest, cheapest, most expensive)
//     (+5 pts): get a suggested order for a customer based on his order history)
//     (+5 pts): display some statistics based on order history)
using StoreModels;

namespace EcommerceBusinessLayer
{
    public interface IAccountBusiness
    {
        // string WelcomeMessage();
        bool addAccount(Account accountObj);
        bool deleteAccount(string Username);
        bool updateAccount(string Username);
        void displayAllAccounts();

    }
}