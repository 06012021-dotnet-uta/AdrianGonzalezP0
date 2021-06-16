using System;
using System.Linq;
using EcommerceDbContext;
using Mapper;
using DbContext;
using StoreCustomer = StoreModels.Customer;
using DbCustomer = EcommerceDbContext.Customer;
using StoreAccount = StoreModels.Account;
using System.Collections.Generic;

namespace EcommerceBusinessLayer
{
    public class CustomerBusiness : ICustomerBusiness
    {
        private Project0Context _context;
        public CustomerBusiness() 
        {
            _context = DbConextProject.DbContext;
        
        }

        public bool addCustomer(StoreCustomer customerObj)
        {
            DbCustomer newCustomer = MapperClassAppToDb.AppCustomerToDbCustomer(customerObj);
            
            try
            {
                _context.Customers.Add(newCustomer);
                _context.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine($"\nCould not save changes\n Error Message: {e.Message}\n");
                return false;
            }
        }

        public bool deleteCustomer(int customerId)
        {
            try
            {
                var customer = _context.Customers.Single(c => c.CustomerId == customerId);
                _context.Customers.Remove(customer);
                _context.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine($"\nCould not remove {customerId}\nError Message: {e.Message}\n");
                return false;
            }
        }
        public List<DbCustomer> searchCustomer(string Fname, string Lname)
        {
            try
            {
                var customer = _context.Customers.Where(c => c.Fname.ToLower() == Fname.Trim().ToLower() && c.Lname.ToLower() == Lname.Trim().ToLower()).ToList();
                return customer;
            } catch (Exception e)
            {
                Console.WriteLine($"Could not find customer with \"{Fname}\" \"{Lname}\"\nError code: {e.Message}");
                return null;
            }
        }

        public DbCustomer searchCustomer(string username)
        {
            try
            {
                var customer = _context.Customers.Single(c => c.Username == username);
                
                return customer;
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine($"Could not find customer with \"{username}\"\nError code: {e.Message}");
                return null;
            }
        }

        public bool updateCustomer(int customerId)
        {
            try
            {
                var customer = _context.Customers.Single(c => c.CustomerId == customerId);
                _context.Customers.Remove(customer);
                _context.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine($"\nCould not remove {customerId}\nError Message: {e.Message}\n");
                return false;
            }
        }

        public long LengthOfCustomer()
        {
            try
            {
                long length = _context.Customers.LongCount();
                return length;

            }
            catch (ArgumentNullException e)
            {

                Console.WriteLine($"Could not retrieve store from database: {e.Message}");
                return 0;
            }
        }

        public void DisplayAllCustomers()
        {
            int num = 1;
            try
            {
                var customers = _context.Customers.OrderBy(customer => customer.Fname);

                foreach (var customer in customers)
                {
                    Console.WriteLine($"{num++}. {customer.Fname} {customer.Lname}");
                }
            }
            catch (ArgumentNullException e)
            {

                throw new Exception($"Could not retrieve store from database: {e.Message}");
            }
        }

        public void DisplayAllCustomers(List<DbCustomer> customers)
        {
            if (customers == null) 
            {
                Console.WriteLine("Empty List");
                goto Exit;
            }

            foreach (var customer in customers)
            {
                string info = $"\n\t\tCustomer Information\nUsername: {customer.Username}\nFirst Name: {customer.Fname}\nLast Name: {customer.Lname}\nAddress: {customer.Address}\nCity: {customer.City}\nState: {customer.State}\nZipcode: {customer.ZipCode}\nContact Number: {customer.ContactNumber}\nEmail: {customer.Email}";
                Console.Write(info);
            }

            Console.WriteLine();

        Exit:;
        }

        public List<DbCustomer> RetrieveAllCostumers()
        {
            try
            {
                var stores = _context.Customers.OrderBy(customer => customer.Fname).ToList();
                return stores;


            }
            catch (ArgumentNullException e)
            {

                throw new Exception($"Could not retrieve store from database: {e.Message}");
            }
        }

        public StoreCustomer createCustomer(StoreAccount newAccount)
        {
            StoreCustomer newCustomer = new();

            // Ask for user's information
            Console.Write("First Name: ");
            newCustomer.Fname = Console.ReadLine().Trim();
            Console.Write("Last Name: ");
            newCustomer.Lname = Console.ReadLine().Trim();
            Console.Write("Street: ");
            newCustomer.Street = Console.ReadLine().Trim();
            Console.Write("City: ");
            newCustomer.City = Console.ReadLine().Trim();
            Console.Write("State: ");
            newCustomer.State = Console.ReadLine().Trim();
            Console.Write("ZipCode: ");
            newCustomer.ZipCode = Console.ReadLine().Trim();
            Console.Write("Email: ");
            newCustomer.Email = Console.ReadLine().Trim();
            Console.Write("Contact Number: ");
            newCustomer.ContactNumber = Console.ReadLine().Trim();

            newCustomer.Username = newAccount.Username;

            return newCustomer;
        }
    } //EOC
} // EON
