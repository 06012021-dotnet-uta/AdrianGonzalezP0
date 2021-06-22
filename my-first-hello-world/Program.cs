using System;
using System.Collections.Generic;

namespace my_first_hello_world
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the object
            Dictionary<Product, int> myDic = new();

            Product first = new("Apple", 12.99m);
            Product second = new("Apple", 12.99m);


            if (myDic.ContainsKey(first))
            {
                myDic[first] = 3;
            }
            else
            {
                myDic.TryAdd(first, 4);
            }

            Console.WriteLine($"Total of items: {myDic.Count}");

        }
    }

    public class Product
    {
        public string ProductName;
        public decimal price;
        public Product(string ProductName, decimal price)
        {
            this.ProductName = ProductName;
            this.price = price;
        }
    }
}