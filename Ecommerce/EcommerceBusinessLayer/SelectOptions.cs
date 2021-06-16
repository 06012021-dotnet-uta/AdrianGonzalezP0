using System;
using System.Collections.Generic;
using DbCustomer = EcommerceDbContext.Customer;
using DbStores = EcommerceDbContext.Store;

namespace EcommerceBusinessLayer
{
    /// <summary>
    /// The SelectionOptions used to guide the user what they want to do.
    /// </summary>
    public class SelectOptions: ISelectionOption
    {
        private readonly DbCustomer _currentUser;
        private readonly OrderBusiness _orderBusiness;
        private readonly StoreBusiness _storeBusiness;
        private readonly CustomerBusiness _customersBusiness;

        private string userInput;       // User input as a string
        private sbyte outResult;          // Convert user's input
        private bool isValid;           // To check if user input is valid

        public SelectOptions(DbCustomer currentUser)
        {
            _orderBusiness = new();
            _storeBusiness = new();
            _customersBusiness = new();
            _currentUser = currentUser;
            userInput = "default";
            outResult = -1;
            isValid = true;
        }

        /// <summary>
        /// After login it prompts user to:
        /// 1. Shop
        /// 2. View Order History 
        /// </summary>
        /// <returns>Returns 1 if user want's to shop. Returns 2 for view History</returns>
        public sbyte UserSelection()
        {

            ResetValues();

            Console.WriteLine($"\t\tWelcome {_currentUser.Fname} {_currentUser.Lname}. What are we doing today?\n");
            do
            {

                if (!isValid || (outResult > 2 || outResult < -1)) DisplayErrors.IncorrectInput(userInput);
                
                Console.WriteLine($"1. Shopping\n2. View Order History\n3. Search Customer by Name\n4. Logout");


                Console.Write("Enter Selection: ");
                userInput = Console.ReadLine();
                isValid = SByte.TryParse(userInput, out outResult);

            } while (!isValid || outResult > 4 || outResult < 1);

            return outResult;
        }

        /// <summary>
        /// Views Order History by:
        /// 1. Store
        /// 2. Customer
        /// 3. Display Details Order
        /// </summary>
        public void ViewOrderHistory()
        {
            ResetValues();

            Console.WriteLine($"\t\tWhich History Would you like to look at?\n");
            do
            {
   
                if (!isValid || (outResult > 2 || outResult < -1)) DisplayErrors.IncorrectInput(userInput);

                Console.WriteLine($"1. Display by Store\n2. Display by Customer\n3. Display Details Order");


                Console.Write("Enter Selection: ");
                userInput = Console.ReadLine();
                isValid = SByte.TryParse(userInput, out outResult);

            } while (!isValid || outResult > 3 || outResult < 1);


            switch (outResult)
            {
                case 1:
                    SelectByStore();
                    break;
                case 2:
                    SelectByCustomer();
                    break;
                case 3:
                    Console.WriteLine("You've Selected by Customer");
                    break;
                default:
                    Console.WriteLine("Not an Option");
                    break;
            }
        }

        /// <summary>
        /// Asks for which store they would like to view 
        /// </summary>
        /// <returns>The Selected option</returns>

        private void SelectByStore()
        {
            ResetValues();

            long storeLength = _storeBusiness.LengthOfStore();

            Console.WriteLine($"\t\tWhich Store Orders would you like to look at?\n");
            do
            {

                if (!isValid || (outResult > 2 || outResult < -1)) DisplayErrors.IncorrectInput(userInput);

                _storeBusiness.DisplayAllStores();

                Console.Write("Enter Selection: ");
                userInput = Console.ReadLine();
                isValid = SByte.TryParse(userInput, out outResult);

            } while (!isValid || outResult > storeLength || outResult < 1);

            // Display Resluts
            SearchByStore(outResult);
        }

        /// <summary>
        /// Searches customer by first and last name
        /// </summary>
        public void SearchCustomerbyName()
        {
            // Ask the name they are looking
            Console.WriteLine("\n\t\tWho are we looking up?\n");
            string lastName = "";
            string firstName = "";

        SEARCH:
            do
            {
                Console.Write("Frist Name: ");
                firstName = Console.ReadLine().Trim();
                Console.Write("Last Name: ");
                lastName = Console.ReadLine().Trim();

                if (firstName == "" || lastName == "")
                {
                    DisplayErrors.IncorrectInput(firstName);
                    DisplayErrors.IncorrectInput(lastName);
                }

            } while (firstName == "" && lastName == "");

            // Grab customer(s) if any.
            List<DbCustomer> customers = _customersBusiness.searchCustomer(firstName, lastName);

            if (customers == null || customers.Count == 0) 
            {
                Console.WriteLine($"\n{customers.Count} results came up.Want to Search again?");
                Console.Write("Press y (yes) or n (n): ");
                string seachAgain = Console.ReadLine();
                Console.WriteLine();

                if (seachAgain.Contains("y")) goto SEARCH;
            }
            _customersBusiness.DisplayAllCustomers(customers);
        }

        /// <summary>
        /// Retrives all of the order based on a store
        /// </summary>
        /// <param name="storeChose"></param>
        private void SearchByStore(int storeChosen)
        {
            // Grab all of the stores
            List<DbStores> listStore = _storeBusiness.RetrieveAllStores();

            // Retrieve Record
            _orderBusiness.displayAllHistoryByStore(listStore[storeChosen - 1].StoreId);

        }

        /// <summary>
        /// Selects user by Customer
        /// </summary>
        private void SelectByCustomer()
        {
            ResetValues();

            long customerLength = _customersBusiness.LengthOfCustomer();

            Console.WriteLine($"\t\tWhich Customer Order's would you like to look at?\n");
            do
            {

                if (!isValid || (outResult > 2 || outResult < -1)) DisplayErrors.IncorrectInput(userInput);

                _customersBusiness.DisplayAllCustomers();

                Console.Write("Enter Selection: ");
                userInput = Console.ReadLine();
                isValid = SByte.TryParse(userInput, out outResult);

            } while (!isValid || outResult > customerLength || outResult < 1);

            SearchByCustomer(outResult);
        }

        /// <summary>
        /// Retrives all of the order based on a store
        /// </summary>
        /// <param name="storeChose"></param>
        private void SearchByCustomer(int userChoice)
        {
            // Grab all of the stores
            List<DbCustomer> listStore = _customersBusiness.RetrieveAllCostumers();

            // Retrieve Record
            _orderBusiness.displayAllHistoryByCustomer(listStore[userChoice - 1].CustomerId);

        }

        /// <summary>
        /// Resets the whenever bofore asking users for their new input.
        /// </summary>
        private void ResetValues()
        {
            userInput = "default";
            outResult = -1;
            isValid = true;
        }
    }
}