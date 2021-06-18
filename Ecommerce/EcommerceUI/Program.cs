using System;
using StoreModels;
using StoreCustomer = StoreModels.Customer;
using DbCustomer = EcommerceDbContext.Customer;
using EcommerceBusinessLayer;

namespace EcommerceUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Location location = new Location();

            Console.WriteLine($"Does have inventory? {location.HasInventory(1,1)}");
        }
    } // EOC
} // EON
