//using System;
//using DbCustomer = EcommerceDbContext.Customer;
//using StoreModels;

//namespace EcommerceBusinessLayer
//{
//    public static class WelcomeScreen
//    {
//        static readonly AccountBusiness accountBusiness = new();
//        static readonly CustomerBusiness customerBusiness = new();

//        /// <summary>
//        /// Displays to user to:
//        /// 1. Login
//        /// 2. Create an Account
//        /// </summary>
//        public static sbyte LoginAndSignup()
//        {
//            string userInput = "default"; // User input as a string
//            sbyte outResult = -1;           // Convert user's input
//            bool isValid = true;          // To check if user input is valid

//            // Ask to login or create account
//            do
//            {
//                if (!isValid || (outResult > 2 || outResult < -1)) DisplayErrors.IncorrectInput(userInput);

//                Console.WriteLine("Select:\n\t1. Login\n\t2. Create an Account\n");

//                Console.Write("Enter Selection: ");
//                userInput = Console.ReadLine();
//                isValid = SByte.TryParse(userInput, out outResult);

//            } while (!isValid || outResult > 2 || outResult < 1);

//            return outResult;
//        }

//         public static void Signup()
//        {
//            Account account;
//            Customer customer;
//            bool isAccountCreated;
//            bool isCustomerCreated;

//            Console.WriteLine("\t\tCreate an account\n");
//            do
//            {
//                account = accountBusiness.CreateAccount();

//                isAccountCreated = accountBusiness.AddAccount(account);

//            } while (!isAccountCreated);

//            Console.WriteLine();

//            Console.WriteLine("\t\tPersonal Information\n");

//            do
//            {
//                customer = customerBusiness.createCustomer(account);

//                isCustomerCreated = customerBusiness.addCustomer(customer);

//            } while (!isCustomerCreated);

//        }

//         public static DbCustomer Login()
//        {
//            string username;
//            string password;
//            bool accountExist = true;
//            Console.WriteLine("\t\tLogin\n");
//            do
//            {
//                if (!accountExist)
//                {
//                    Console.WriteLine("Try Again\n");
//                }

//                Console.Write("Enter username: ");
//                username = Console.ReadLine().Trim();
//                Console.Write("Enter password: ");
//                password = Console.ReadLine();

//                accountExist = accountBusiness.Credentials(username, password);

//            } while (!accountExist);

//            // User information
//            DbCustomer user = customerBusiness.searchCustomer(username);

//            return user;

//        }
//    }
//}
