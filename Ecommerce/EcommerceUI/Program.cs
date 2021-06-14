using System;
using StoreModels;
using EcommerceBusinessLayer;

namespace EcommerceUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account("agonzalez108", "123456");
            Customer customer = new Customer(account, "Adrian", "Gonzalez", "13170 Saker Dr", "El Paso", "Texas", "79928", "(915)352-9166", "adrian.gonzalez@revature.net");

            Console.WriteLine(customer.customerInfo());


            // Testing Products and Category(Types)
            Category category1 = new Category(1, "Laptop");
            Category category2 = new Category(2, "Desktop");
            Category category3 = new Category(3, "Monitor");
            Category category4 = new Category(4, "Shoes");

            Product product1 = new Product("Asus", 1799.33m, "One of the best latop ever", category1);
            Product product2 = new Product("Dell", 2799.33m, "One of the best Desktops ever", category2);
            Product product3 = new Product("LG", 199.33m, "One of the best Monitors ever", category3);
            Product product4 = new Product("Jordan", 99.33m, "One of the best Shoes ever", category4);

            Console.WriteLine(product1.productInfo());
            Console.WriteLine();
            Console.WriteLine(product2.productInfo());
            Console.WriteLine();
            Console.WriteLine(product3.productInfo());
            Console.WriteLine();
            Console.WriteLine(product4.productInfo());
        }
    }
}
