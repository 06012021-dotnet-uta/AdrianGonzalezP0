using System;
using StoreModels;
using System.Threading.Tasks;
using EcommerceBusinessLayer;
using System.Collections.Generic;
using CustomerModel = StoreModels.Customer;
using StoreModel = StoreModels.Store;
using Store = EcommerceBusinessLayer.Store;

namespace EcommerceUI
{
    class Program
    {
        static readonly Store stores = new();  // Store
        static readonly Login login = new();   // Login
        static readonly Signup signup = new(); // Signup

        static string userInput = "default"; // User input as a string
        static sbyte outResult = -1;           // Convert user's input
        static bool isValid = true;
        static async Task Main(string[] args)
        {
          
            CustomerModel currentUser;

            do
            {
                Console.WriteLine("\t\tWelcome To MyEcommerce\n");
                // Ask to login or create account
                do
                {
                    if (!isValid || (outResult > 2 || outResult < -1)) DisplayErrors.IncorrectInput(userInput);

                    Console.WriteLine("Select:\n\t1. Login\n\t2. Create an Account\n");

                    Console.Write("Enter Selection: ");
                    userInput = Console.ReadLine();
                    isValid = SByte.TryParse(userInput, out outResult);

                } while (!isValid || outResult > 2 || outResult < 1);

                // Flush Previous user choices
                Flush();
               
                // Sigup process
                if (outResult == 2)
                {
                     await Signup();
                }

                // Login
                currentUser = Login();


                // Flush Previous user choices
                Flush();

                // Go shopping, checkOrders history, or LookupCustomer
                Console.WriteLine($"\n\t\t*What are we doing today {currentUser.Fname}?*\n");
                do
                {
                    Console.WriteLine($"1. Shopping\n2. View Order History\n3. Search Customer by Name\n4. Logout");


                    Console.Write("Enter Selection: ");
                    userInput = Console.ReadLine();
                    isValid = SByte.TryParse(userInput, out outResult);

                    switch (outResult)
                    {
                        case 1:
                            Shopping(currentUser);
                            break;
                        case 2:
                            CheckOrders(currentUser);
                            break;
                        case 3:
                            LookupCustomer();
                            break;
                        case 4:
                            Console.WriteLine($"\n\t\tSee you later {currentUser.Fname} {currentUser.Lname}. Come back soon!\n");
                            break;
                        default:
                            DisplayErrors.IncorrectInput(userInput);
                            break;
                    }

                } while (!isValid || outResult > 4);

                Flush();

                Console.WriteLine($"\n\n");
            } while (true);

        }

        static CustomerModel Login() 
        {
            Console.WriteLine("\n\t\t*Login to MyEcommerce*\n");

            Account account = new();
            bool isLoggedIn = true;

            do {

                if (!isLoggedIn) DisplayErrors.IncorrectLogin();
               

                // Ask username and password
                Console.Write("Username: ");
                account.Username = Console.ReadLine();
                Console.Write("Password: ");
                account.Password = Console.ReadLine();

                isLoggedIn = login.LoginUser(account);

            } while (!isLoggedIn);

            return login.GetUserInfo(account);

        }

        /// <summary>
        /// Ask info to signup
        /// </summary>
        /// <returns></returns>
        static async Task Signup() 
        {
            Console.WriteLine("\n\t\t*Signup to MyEcommerce*\n");
            Account account = new();
            bool isAccountCreated = true;

            // Create Account First
            do
            {

                if (!isAccountCreated) DisplayErrors.IncorrectLogin();


                // Ask username and password
                Console.Write("Username: ");
                account.Username = Console.ReadLine();
                Console.Write("Password: ");
                account.Password = Console.ReadLine();

                isAccountCreated = await signup.CreateAccount(account);

            } while (!isAccountCreated);

            CustomerModel customer = new();
            bool isCustomerCreated = true;
            do
            {
                if (!isCustomerCreated) DisplayErrors.IncorrectLogin();

                Console.Write("First Name: ");
                customer.Fname = Console.ReadLine();
                Console.Write("Last Name: ");
                customer.Lname = Console.ReadLine();
                Console.Write("Street: ");
                customer.Street = Console.ReadLine();
                Console.Write("City: ");
                customer.City = Console.ReadLine();
                Console.Write("State: ");
                customer.State = Console.ReadLine();
                Console.Write("ZipCode: ");
                customer.ZipCode = Console.ReadLine();
                Console.Write("Phone Number: ");
                customer.ContactNumber = Console.ReadLine();
                Console.Write("Email: ");
                customer.Email = Console.ReadLine();

                customer.Username = account.Username;

                isCustomerCreated = await signup.CreateCustomer(customer);

            } while (!isCustomerCreated);
        }
        static void Shopping(CustomerModel currentUser) 
        {
            // Select store to shop
            List<StoreModel> listOfStore = stores.GetAllStore();
            int storeid;
            int numberOfStores = listOfStore.Count;
            int selection = 1;

            Console.WriteLine($"\n\t\t*Welcome {currentUser.Fname}. Where are we shopping today?*\n");
            do
            {
                if (!isValid || (outResult > 2 || outResult < -1)) DisplayErrors.IncorrectInput(userInput);

                foreach (StoreModel store in listOfStore)
                {
                    Console.WriteLine($"Select: {selection++}.\n\tStore Name: {store.StoreName}\n\tStreet: {store.Street}\n");
                }

                Console.Write("Enter Selection: ");
                userInput = Console.ReadLine();
                isValid = SByte.TryParse(userInput, out outResult);

            } while (!isValid || outResult > numberOfStores || outResult < 1);

            // Get StoreId
            storeid = listOfStore[outResult - 1].StoreId;
        }
        static void CheckOrders(CustomerModel currentUser) { }
        static void LookupCustomer() { }

        static void Flush()
        {
            userInput = "default"; // User input as a string
            outResult = -1;           // Convert user's input
            isValid = true;
        }
    } // EOC
} // EON
