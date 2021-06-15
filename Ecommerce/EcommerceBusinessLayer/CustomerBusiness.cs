using System;
using System.Linq;
using EcommerceDbContext;
using Mapper;
using DbContext;
using StoreCustomer = StoreModels.Customer;
using DbCustomer = EcommerceDbContext.Customer;
using StoreAccount = StoreModels.Account;

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
                Console.WriteLine($"\nError Message: {e.Message}\n");
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
        public DbCustomer searchCustomer(string Fname, string Lname)
        {
            try
            {
                var customer = _context.Customers.Single(c => c.Fname.ToLower() == Fname.Trim().ToLower() && c.Lname == Lname.Trim().ToLower());
                return customer;
            } catch (Exception e)
            {
                throw new Exception($"Could not find customer with \"{Fname}\" \"{Lname}\"\nError code: {e.Message}");
            }
        }

        public DbCustomer searchCustomer(string username)
        {
            try
            {
                var customer = _context.Customers.Single(c => c.Username == username);
                
                return customer;
            }
            catch (Exception e)
            {
                throw new Exception($"Could not find customer with \"{username}\"\nError code: {e.Message}");
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
            newCustomer.Zipcode = Console.ReadLine().Trim();
            Console.Write("Email: ");
            newCustomer.Email = Console.ReadLine().Trim();
            Console.Write("Contact Number: ");
            newCustomer.ContactNumber = Console.ReadLine().Trim();

            newCustomer.Account = newAccount;

            return newCustomer;
        }
    } //EOC
} // EON
