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
        static readonly OrderBusiness orderBusiness = new(); // Orders
        static readonly ProductBusiness productBusiness = new(); // Products
        static readonly CustomerBusiness customerBusiness = new(); // Customer

        static string userInput = "default"; // User input as a string
        static sbyte outResult = -1;           // Convert user's input
        static bool isValid = true;
        static void Main(string[] args)
        {
            //CustomerModel dummy = new()
            //{
            //    CustomerId = 2,
            //    Fname = "Dummy",
            //    Lname = "Dude",
            //    Username = "Fdsafdsa@gmail.com"
            //};

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
                    isValid = sbyte.TryParse(userInput, out outResult);

                } while (!isValid || outResult > 2 || outResult < 1);

                // Flush Previous user choices
                Flush();
               
                // Sigup process
                if (outResult == 2)
                {
                    Signup();
                }

                // Login
                currentUser = Login();


                // Flush Previous user choices
                Flush();


                // Go shopping, checkOrders history, or LookupCustomer
                do
                {
                    Console.WriteLine($"\n\t\t*What are we doing today {currentUser.Fname}?*\n");
                    Console.WriteLine($"1. Shopping\n2. View Order History\n3. Search Customer by Name\n4. Logout");


                    Console.Write("Enter Selection: ");
                    userInput = Console.ReadLine();
                    isValid = sbyte.TryParse(userInput, out outResult);

                    switch (outResult)
                    {
                        case 1:
                            Shopping(currentUser);
                            break;
                        case 2:
                            OrderHistory(currentUser);
                            break;
                        case 3:
                            LookupCustomer(currentUser);
                            break;
                        case 4:
                            Console.WriteLine($"\n\t\t---See you later {currentUser.Fname} {currentUser.Lname}. Come back soon!---");
                            break;
                        default:
                            DisplayErrors.IncorrectInput(userInput);
                            break;
                    }

                } while (!isValid || outResult < 4);

                Flush();

                Console.WriteLine($"\n");
            } while (true);

        }

        /// <summary>
        /// Logins user
        /// </summary>
        /// <returns></returns>
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
        static void Signup() 
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

                isAccountCreated =  signup.CreateAccount(account);

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

                isCustomerCreated = signup.CreateCustomer(customer);

            } while (!isCustomerCreated);
        }

        /// <summary>
        /// Customer shopping sections
        /// </summary>
        /// <param name="currentUser"></param>
        static void Shopping(CustomerModel currentUser) 
        {
            List<StoreModel> locations = stores.GetAllStore();
            List<Inventory> inventories;
            List<Product> products;
            bool continueShopping = true;
            int storeId;
            do
            {
                Console.WriteLine($"\n\t\t*Welcome {currentUser.Fname}. Where are we shopping today?*\n");

                // Validates users input and display all stores location
                ValidateUserInput(locations.Count, listOfStores: locations);

                // Get StoreId
                storeId = locations[outResult - 1].StoreId;

                // Grab stores inventory
                inventories = stores.GrabAllInventory(storeId);

                // Create Shopping cart
                Shopping shoppingCart = new(currentUser.CustomerId, storeId,  inventories);
                
                bool isCheckout = true;

                // Show all of the products available and validate user input
                string option;
                sbyte optionSbyte = 1;
                int Quantity;
                do
                {

                    // Grab Products based on store location
                    products = shoppingCart.GrabAllProducts();
                    int numProducts = products.Count;
                    bool isCoverted;

                    // Start adding items to the cart
                    switch (optionSbyte)
                    {
                        case 1:
                            // Validates user input for product
                            ValidateUserInput(numProducts, listOfProducts: products);
                            Product product = products[outResult - 1];
                            int quantity = inventories.Find(inventory => inventory.ProductId == product.ProductId).Quantity;
                            Console.WriteLine($"How many would like to take? {product.ProductName} Quantity: {quantity}\n");
                            Console.Write("Enter Quantity: ");
                            option = Console.ReadLine();
                            isCoverted = int.TryParse(option, out Quantity);
                            if (!isCoverted)
                            {
                                Console.WriteLine("Error - Incorrect Input");
                            } else
                            {
                                shoppingCart.AddItem(product, Quantity);
                            }
                            break;
                        case 2:
                            // User checks out
                            string total = shoppingCart.CheckOut(products);
                            Console.WriteLine(total);
                            Console.Write("\nShop at another location?\nEnter Yes or No: ");
                            string input = Console.ReadLine();
                            continueShopping = input.ToLower().Contains("y");
                            isCheckout = false;
                            break;
                        default:
                            break;
                    }
                    
                    // Reset userinput
                    Flush();
                    if (isCheckout)
                    {
                        Console.WriteLine($"1. Add Another Item\n2. Checkout\n");
                        Console.Write("Select Option: ");
                        option = Console.ReadLine();
                        sbyte.TryParse(option, out optionSbyte);
                    }

                } while (isCheckout);

            } while (continueShopping);
            
            Console.WriteLine($"\n\n");

            //Reset userinput
            Flush();
        }

        /// <summary>
        /// CheckOrders
        /// </summary>
        /// <param name="currentUser"></param>
        static void OrderHistory(CustomerModel currentUser) 
        {
            // Reset inputs
            Flush();

            Console.WriteLine($"\n\t\t*Welcome {currentUser.Fname}. Which orders are we looking for?*\n");
            List<Order> orders = new();
            List<StoreModel> storeList = stores.GetAllStore();
            int lengthOfStores = storeList.Count;
            //List<Product> products = productBusiness.GetAllProduct();
            bool isDone = false;

            // Loop Until done
            do
            {
                // Select View order by: Store, detial, or all orders
                do
                {
                    if (!isValid || (outResult > 2 || outResult < -1)) DisplayErrors.IncorrectInput(userInput);

                    Console.WriteLine($"\n1. By Store\n2. {currentUser.Fname}'s Order\n3. All Orders\n4. Exit");

                    Console.Write("Enter Selection: ");
                    userInput = Console.ReadLine();
                    isValid = sbyte.TryParse(userInput, out outResult);

                } while (!isValid || outResult > 4 || outResult < 1);

                switch (outResult)  
                {
                    case 1:
                        ValidateUserInput(lengthOfStores, listOfStores: storeList);
                        orders = orderBusiness.GetOrderByStoreId(storeList[outResult-1].StoreId);
                        break;
                    case 2:
                        orders = orderBusiness.GetOrderByCustomerId(currentUser.CustomerId);
                        break;
                    case 3:
                        orders = orderBusiness.GetAllOrders();
                        break;
                    case 4:
                        isDone = true;
                        break;
                }

                Console.WriteLine("\n\t\t--Orders History--\n");
                foreach (var order in orders)
                {
                    Console.WriteLine(order.GetOrderInfo());
                }
                Console.WriteLine("\n\t\t------------------\n");

                Flush();

            } while (!isDone);


        }

        /// <summary>
        /// Display a customers info
        /// </summary>
        /// <param name="currentUser"></param>
        static void LookupCustomer(CustomerModel currentUser) 
        {
            bool isSearching = true;
            do
            {
                Console.WriteLine($"\n\tSearch Customer\n");
                Console.Write("Enter First Name: ");
                string fname = Console.ReadLine();
                Console.Write("Enter Last Name: ");
                string lname = Console.ReadLine();

                List<Customer> customers = customerBusiness.SearchCustomer(fname, lname);

                if (customers.Count > 0)
                {
                    Console.WriteLine("---Customer(s) Information---");
                    foreach (Customer customer in customers)
                    {
                        Console.WriteLine(customer.customerInfo());
                    }
                    Console.WriteLine("\n-----------------------------\n");
                }

                Console.Write("Continue Searching... yes or no? ");
                string input = Console.ReadLine();

                isSearching = input.ToLower().Contains('y');

            } while (isSearching);
        }


        /// <summary>
        /// Flushes out users last input
        /// </summary>
        static void Flush()
        {
            userInput = "default"; // User input as a string
            outResult = -1;           // Convert user's input
            isValid = true;
        }

        /// <summary>
        /// Validate user input 
        /// </summary>
        /// <param name="length"></param>
        /// <param name="listOfProducts"></param>
        /// <param name="listOfStores"></param>
        static void ValidateUserInput(int length, List<Product> listOfProducts = null, List<StoreModel> listOfStores = null)
        {
            
            if (listOfProducts != null)
            {
                do
                {
                    int selection = 1;

                    if (!isValid || (outResult > 2 || outResult < -1)) DisplayErrors.IncorrectInput(userInput);

                    Console.WriteLine("\tSelect One of the Product:\n");
                    foreach (Product product in listOfProducts)
                    {
                        Console.WriteLine($"({selection++}.) {product.productInfo()}\n");
                    }

                    Console.Write("Enter Selection: ");
                    userInput = Console.ReadLine();
                    isValid = SByte.TryParse(userInput, out outResult);

                } while (!isValid || outResult > length || outResult < 1);
            }
            else
            {
                do
                {
                    int selection = 1;

                    if (!isValid || (outResult > 2 || outResult < -1)) DisplayErrors.IncorrectInput(userInput);

                    Console.WriteLine("\tSelect a Store Location:\n");
                    foreach (StoreModel store in listOfStores)
                    {
                        Console.WriteLine($" ({selection++}).\n\tStore Name: {store.StoreName}\n\tStreet: {store.Street}\n");
                    }

                    Console.Write("Enter Selection: ");
                    userInput = Console.ReadLine();
                    isValid = sbyte.TryParse(userInput, out outResult);

                } while (!isValid || outResult > length || outResult < 1);
            }
        }
    } // EOC
} // EON