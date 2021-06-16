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

            DbCustomer user;
            sbyte userChoice;
            do { 
                // Welcome Screen
                userChoice = WelcomeScreen.LoginAndSignup();

                if (userChoice == 2) WelcomeScreen.Signup();

                user = WelcomeScreen.Login();

                Console.WriteLine();

                // User Selection
                SelectOptions selectOptions = new(user);
                sbyte userSelects;
                do
                {
                    userSelects = selectOptions.UserSelection();

                    switch (userSelects)
                    {
                        case 1:
                            Console.WriteLine("Lets go shopping");
                            break;
                        case 2:
                            selectOptions.ViewOrderHistory();
                            break;
                        case 3:
                            selectOptions.SearchCustomerbyName();
                            break;
                        default:
                            Console.WriteLine("Are you sure you want to exit?");
                            Console.Write("Type n (no) or y (yes): ");
                            string logout = Console.ReadLine().Trim();
                            userSelects = (sbyte)(logout.ToLower().Contains("y") ? 4 : 1);
                            break;
                    }

                } while (userSelects != 4); // Selection Part
            } while(true); // Actuall Program
        }
    } // EOC
} // EON
