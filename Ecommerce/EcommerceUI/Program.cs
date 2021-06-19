using System;
using StoreModels;
using StoreCustomer = StoreModels.Customer;
using DbCustomer = EcommerceDbContext.Customer;
using System.Threading.Tasks;
using EcommerceBusinessLayer;
using System.Collections.Generic;
using Store = EcommerceBusinessLayer.Store;

namespace EcommerceUI
{
    class Program
    {
        static readonly Store stores = new();// Store
        // Shopping
        // Login
        // Signup

        static async Task Main(string[] args)
        {

            do
            {
                // Login or SignUp

                // Select store to shop at

                // Go shopping, checkOrders history, or LookupCustomer
            } while (true);

        }

        static void Login() { }
        static void Signup() { }
        static void Shopping() { }
        static void CheckOrders() { }
        static void LookupCustomer() { }
    } // EOC
} // EON
