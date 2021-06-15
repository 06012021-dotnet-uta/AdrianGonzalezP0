using System;
using StoreModels;
using StoreCustomer = StoreModels.Customer;
using DbCustomer = EcommerceDbContext.Customer;
using EcommerceBusinessLayer;

namespace EcommerceUI
{
    class Program
    {
        static readonly AccountBusiness accountBusiness = new();
        static readonly CustomerBusiness customerBusiness = new();
        static readonly OrderHistory orderHistory = new();
        static void Main(string[] args)
        {
  
            string userInput = "default"; // User input as a string
            int outResult = -1;           // Convert user's input
            bool isValid = true;          // To check if user input is valid

            // Welcome User
            Console.WriteLine("\t\tWelcome to Ecommerce Project");

            // Ask to login or create account
            do
            {
                if (!isValid || (outResult > 2 || outResult < -1))
                {
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine($"\n {userInput} is NOT a valid choice.\n Select again.\n");
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                }
                Console.WriteLine("Select:\n\t1. Login\n\t2. Create an Account\n");

                Console.Write("Enter Selection: ");
                userInput = Console.ReadLine();
                isValid = Int32.TryParse(userInput, out outResult);

            } while (!isValid || outResult > 2 || outResult < 1);


            Console.WriteLine("****************************************************************");

            // Login or Create an account
            if (outResult == 1)
            {
                Login();
                    
            } else
            {
                Signup();
            }
        }

        /// <summary>
        /// Creates an account and profile for user
        /// </summary>
        static void Signup () 
        {
            Account account;
            Customer customer;
            bool isAccountCreated;
            bool isCustomerCreated;

            Console.WriteLine("\t\tCreate an account\n");
            do
            {
                account = accountBusiness.createAccount();

                isAccountCreated = accountBusiness.addAccount(account);

            } while (!isAccountCreated);

            Console.WriteLine();

            Console.WriteLine("\t\tPersonal Information\n");

            do
            {
                customer = customerBusiness.createCustomer(account);
              
                isCustomerCreated = customerBusiness.addCustomer(customer);
            
            } while (!isCustomerCreated);

            //User must login once they are done creating an account
            Login();

        }

        static void Login() 
        {
            string username;
            string password;
            bool accountExist = true;
            Console.WriteLine("\t\tLogin\n");
            do
            {
                if(!accountExist)
                {
                    Console.WriteLine("Try Again\n");
                }

                Console.Write("Enter username: ");
                username = Console.ReadLine().Trim();
                Console.Write("Enter password: ");
                password = Console.ReadLine();

                accountExist = accountBusiness.credentials(username, password);

            } while (!accountExist);

            // User information
            DbCustomer user = customerBusiness.searchCustomer(username);

            Console.WriteLine("****************************************************************");

            UserSelection(user);
        }
        static void UserSelection(DbCustomer customer)
        {
            string userInput = "default"; // User input as a string
            int outResult = -1;           // Convert user's input
            bool isValid = true;          // To check if user input is valid

            Console.WriteLine($"\t\tWelcome {customer.Fname} {customer.Lname}. What are we doing today?\n");
            do
            {
                if (!isValid || (outResult > 2 || outResult < -1))
                {
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine($"\n {userInput} is NOT a valid choice.\n Select again.\n");
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                }
                Console.WriteLine($"1. Shopping\n2. View Order History\n");


                Console.Write("Enter Selection: ");
                userInput = Console.ReadLine();
                isValid = Int32.TryParse(userInput, out outResult);

            } while (!isValid || outResult > 2 || outResult < 1);

            if (outResult == 1)
            {

            } else
            {
                ViewOrderHistory();
            }
        }

        static void ViewOrderHistory()
        {
            string userInput = "default"; // User input as a string
            int outResult = -1;           // Convert user's input
            bool isValid = true;          // To check if user input is valid

            Console.WriteLine($"\t\tWhich History Would you like to look at?\n");
            do
            {
                if (!isValid || (outResult > 2 || outResult < -1))
                {
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine($"\n {userInput} is NOT a valid choice.\n Select again.\n");
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                }
                Console.WriteLine($"1. Display by Store\n2. Display by Customer\n");


                Console.Write("Enter Selection: ");
                userInput = Console.ReadLine();
                isValid = Int32.TryParse(userInput, out outResult);

            } while (!isValid || outResult > 2 || outResult < 1);
        }
    } // EOC
} // EON
